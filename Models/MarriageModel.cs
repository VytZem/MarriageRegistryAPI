using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageRegistryAPI.Models
{
    public class MarriageModel
    {
        public int MarriageId { get; set; }
        [Required]
        public DateTime MarriageDate { get; set; }
        public List<PersonModel> Persons { get; set; }
    }
}
