using AutoMapper;
using Core.Entities.Concrete;
using Core.Entities.Dtos;

namespace Business.Helpers
{
    public class AutoMapperHelper : Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<User, LoginingUser>().ReverseMap();
            CreateMap<User, UserForRegisterDto>().ReverseMap();

        }
    }
}
