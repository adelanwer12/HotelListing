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
    public class HotelsConfigurations: Profile
    {
        public HotelsConfigurations()
        {
            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<Hotel, CreateHotelDto>().ReverseMap();
            CreateMap<Hotel, UpdateHotelDto>().ReverseMap();
        }
    }
}
