using AuthenticationEntity.Dtos;
using AuthenticationEntity.Entities;
using AutoMapper;

namespace AuthenticationApi
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {

            CreateMap<User, RegistrationRequestDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }

    }
}
