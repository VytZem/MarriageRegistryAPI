using MarriageRegistryAPI.Persistence.Entities;
using MarriageRegistryAPI.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageRegistryAPI.Persistence.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(MarriageRegistryContext dbContext) : base(dbContext)
        {

        }
        public async Task<Person> GetByPersonalCode(string personalCode)
        {
            return await _dbContext.Persons.FirstOrDefaultAsync(p => p.PersonalCode == personalCode);
        }
        public async Task<List<Person>> GetPersonsByMarriageId(int marriageId)
        {
            return await _dbContext.Persons.Where(p => p.MarriageId == marriageId).ToListAsync();
        }
    }
}
