using AutoMapper;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Profiles
{
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<User, LoginingUser>();
            CreateMap<LoginingUser,User>();
        }
    }
}
