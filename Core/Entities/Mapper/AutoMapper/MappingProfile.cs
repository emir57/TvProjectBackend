using AutoMapper;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Mapper.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, LoginingUser>();
            CreateMap<LoginingUser, User>();
        }
    }
}
