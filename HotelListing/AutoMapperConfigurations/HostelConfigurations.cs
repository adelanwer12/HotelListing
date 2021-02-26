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
    public class HostelConfigurations: Profile
    {
        public HostelConfigurations()
        {
            CreateMap<Hostel, HostelDto>().ReverseMap();
            CreateMap<Hostel, CreateHostelDto>().ReverseMap();
            CreateMap<Hostel, UpdateHostelDto>().ReverseMap();
        }
    }
}
