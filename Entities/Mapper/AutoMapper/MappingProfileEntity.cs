using AutoMapper;
using Core.Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Mapper.AutoMapper
{
    public class MappingProfileEntity : Profile
    {
        public MappingProfileEntity()
        {
            CreateMap<UpdateUserDto, User>()
                .ForMember(member => member.Id, member2 => member2.MapFrom(x => x.UserId));
            CreateMap<User, UpdateUserDto>()
                .ForMember(member => member.UserId, member2 => member2.MapFrom(x => x.Id));
        }
    }
}
