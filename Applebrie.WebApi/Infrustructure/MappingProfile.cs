using Applebrie.Core.Dtos;
using Applebrie.Core.Entities;
using AutoMapper;

namespace Applebrie.WebApi.Infrustructure
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<UserType, UserTypeDto>();

            CreateMap<User, UserDto>();
            //.ForMember(dest => dest.UserTypeName, opt => opt.MapFrom(src => src.UserType.Name));
        }
    }
}
