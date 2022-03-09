using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageRegistryAPI.Persistence.Entities
{
    public class Marriage
    {
        public int MarriageId { get; set; }
        public DateTime MarriageDate { get; set; }

        public IList<Person> Spouses { get; set; }

    }
}
