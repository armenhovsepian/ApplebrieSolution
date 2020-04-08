using Applebrie.Core.Dtos;
using Applebrie.Core.Entities;
using Applebrie.Core.Interfaces;
using Applebrie.WebApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Applebrie.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class UsersController : ControllerBase
    {
        private readonly IUserTypeRepository _userTypeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserTypeRepository userTypeRepository, IUserRepository userRepository, IMapper mapper)
        {
            _userTypeRepository = userTypeRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> GetUsers()
        {
            var users = await _userRepository.ListAllWithUserTypeAsync();
            var userDtos = users.Select(user => _mapper.Map<UserDto>(user));
            return Ok(userDtos);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var data = await _userRepository.GetByIdWithUserTypeAsync(id);

            if (data == null) return NotFound();

            return Ok(_mapper.Map<UserDto>(data));
        }


        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] UserFormModel model)
        {
            var userType = await _userTypeRepository.GetByIdAsync(model.UserType.Id);
            if (userType == null) return BadRequest();

            var user = new User {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserTypeId = userType.Id
                
            };
            await _userRepository.AddAsync(user);

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null) return NotFound();

            await _userRepository.DeleteAsync(user);

            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserFormModel model)
        {
            if (id != model.Id) return BadRequest();

            var userType = await _userTypeRepository.GetByIdAsync(model.UserType.Id);
            if (userType == null) return BadRequest();

            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return NotFound();

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.UserTypeId = userType.Id;
            user.Modified = DateTime.UtcNow;

            await _userTypeRepository.UpdateAsync(userType);

            return NoContent();
        }
    }
}