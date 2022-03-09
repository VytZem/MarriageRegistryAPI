using MarriageRegistryAPI.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageRegistryAPI.Persistence.Repositories.Interfaces
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        Task<List<Person>> GetPersonsByMarriageId(int marriageId);
        Task<Person> GetByPersonalCode(string personalCode);
    }
}
