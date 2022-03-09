using MarriageRegistryAPI.Persistence.Entities;
using MarriageRegistryAPI.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageRegistryAPI.Persistence.Repositories
{
    public class MarriageRepository : BaseRepository<Marriage>, IMarriageRepository
    {
        public MarriageRepository(MarriageRegistryContext dbContext) : base(dbContext)
        {

        }
    }
}
