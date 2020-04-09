using Applebrie.Core.Dtos;
using Applebrie.Core.Entities;
using AutoMapper;

namespace Applebrie.WebApi.Infrustructure
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            MapFromDomainObject();
            MapToDomainObject();
        }

        private void MapFromDomainObject()
        {
            CreateMap<UserType, UserTypeDto>();
            CreateMap<User, UserDto>();
        }

        private void MapToDomainObject()
        {
            CreateMap<UserTypeDto, UserType>();
        }
    } 
}
