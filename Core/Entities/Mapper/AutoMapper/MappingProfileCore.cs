using AutoMapper;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Mapper.AutoMapper
{
    public class MappingProfileCore : Profile
    {
        public MappingProfileCore()
        {
            CreateMap<User, LoginingUser>();
            CreateMap<LoginingUser, User>();
        }
    }
}
