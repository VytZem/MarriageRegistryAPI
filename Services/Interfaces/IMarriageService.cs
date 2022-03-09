using MarriageRegistryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MarriageRegistryAPI.Services.Interfaces
{
    public interface IMarriageService
    {
       Task<List<MarriageModel>> GetAllMarriageRecordsAsync();
       Task<int> CreateMarriageRecordAsync(MarriageModel marriageModel);
    }
}
