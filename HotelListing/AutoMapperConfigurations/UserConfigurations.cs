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
    public class UserConfigurations: Profile
    {
        public UserConfigurations()
        {
            CreateMap<ApiUser, UserDto>().ReverseMap();
            CreateMap<ApiUser, CreateUserDto>().ReverseMap();
            CreateMap<ApiUser, UpdateUserDto>().ReverseMap();
        }
    }
}
