using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HotelListing.Models;
using HotelListing.ViewModels.Create;
using HotelListing.ViewModels.Return;
using HotelListing.ViewModels.Update;

namespace HotelListing.AutoMapperConfigurations
{
    public class CountryConfigurations : Profile
    {
        public CountryConfigurations()
        {
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, CreateCountryDto>().ReverseMap();
            CreateMap<Country, UpdateCountryDto>().ReverseMap();
        }
    }
}
