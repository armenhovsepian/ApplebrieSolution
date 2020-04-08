using Applebrie.Core.Dtos;
using Applebrie.Core.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Applebrie.Infrastructure.Services
{
    public class UserTypeService : IUserTypeService
    {
        private readonly IUserTypeRepository _userTypeRepository;
        private readonly IMapper _mapper;

        public UserTypeService(IUserTypeRepository userTypeRepository, IMapper mapper)
        {
            _userTypeRepository = userTypeRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<UserTypeDto>> GetAllAsync()
        {
            var userTypes = await _userTypeRepository.ListAllAsync();
            return userTypes.Select(user => _mapper.Map<UserTypeDto>(user));
        }
    }
}
