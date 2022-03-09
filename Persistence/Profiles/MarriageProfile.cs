using AutoMapper;
using MarriageRegistryAPI.Models;
using MarriageRegistryAPI.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageRegistryAPI.Persistence.Profiles
{
    public class MarriageProfile : Profile
    {
        public MarriageProfile()
        {
            this.CreateMap<Marriage, MarriageModel>().ReverseMap();
        }
    }
}
