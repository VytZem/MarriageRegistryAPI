using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarriageRegistryAPI.Persistence;
using MarriageRegistryAPI.Persistence.Entities;
using MarriageRegistryAPI.Models;
using MarriageRegistryAPI.Services.Interfaces;

namespace MarriageRegistryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarriagesController : ControllerBase
    {
        private readonly MarriageRegistryContext _context;
        private readonly IMarriageService _marriageService;

        public MarriagesController(MarriageRegistryContext context, IMarriageService marriageService)
        {
            _context = context;
            _marriageService = marriageService;
        }

        // GET: api/Marriages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarriageModel>>> GetMarriages()
        {
            return await _marriageService.GetAllMarriageRecordsAsync();
        }

        // GET: api/Marriages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Marriage>> GetMarriage(int id)
        {
            var marriage = await _context.Marriages.FindAsync(id);

            if (marriage == null)
            {
                return NotFound();
            }

            return marriage;
        }

       
        // POST: api/Marriages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<int>> PostMarriage([FromBody] MarriageModel marriageModel)
        {
            var marriageId = await _marriageService.CreateMarriageRecordAsync(marriageModel);

            return Ok(marriageId);
        }
    }
}
