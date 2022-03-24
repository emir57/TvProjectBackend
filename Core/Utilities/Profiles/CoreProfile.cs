using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Core.Entities.Concrete;
using Core.Entities.Dtos;

namespace Core.Utilities.Profiles
{
    public class CoreProfile : Profile
    {
        public CoreProfile()
        {
            CreateMap<User, UserForRegisterDto>();
            CreateMap<UserForRegisterDto, User>();
        }
    }
}
