using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountryAPI_API.Models;
using CountryAPI.Entities;

namespace CountryAPI_API.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<CountryEntity, Country>();
        }
    }
}
