using Applebrie.Core.Dtos;
using Applebrie.Core.Entities;
using Applebrie.Core.Interfaces;
using Applebrie.WebApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Applebrie.WebApi.Controllers
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.1&tabs=visual-studio
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypesController : ControllerBase
    {
        private readonly IUserTypeService _userTypeService;
        private readonly IUserTypeRepository _userTypeRepository;
        private readonly IMapper _mapper;


        public UserTypesController(IUserTypeService userTypeService, IUserTypeRepository userTypeRepository, IMapper mapper)
        {
            _userTypeService = userTypeService;
            _userTypeRepository = userTypeRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserTypeDto>>> GetUserTypes(CancellationToken ct)
        {
            var data = await _userTypeService.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserTypeDto>> GetUserType(int id)
        {
            var data = await _userTypeRepository.GetByIdAsync(id);

            if (data == null) return NotFound();

            return Ok(_mapper.Map<UserTypeDto>(data));
        }


        [HttpPost]
        public async Task<ActionResult> CreateUserType([FromBody] UserTypeFormModel model)
        {
            var userType = new UserType{ Name = model.Name };

            await _userTypeRepository.AddAsync(userType);

            return CreatedAtAction(nameof(GetUserType), new { id = userType.Id }, userType);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserType(int id)
        {
            var userType = await _userTypeRepository.GetByIdAsync(id);

            if (userType == null) return NotFound();

            await _userTypeRepository.DeleteAsync(userType);

            return NoContent();
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserType(int id, UserTypeFormModel model)
        {
            if (id != model.Id) return BadRequest();

            var userType = await _userTypeRepository.GetByIdAsync(id);
            if (userType == null) return NotFound();

            userType.Name = model.Name;
            userType.Modified = DateTime.UtcNow;

            await _userTypeRepository.UpdateAsync(userType);

            return NoContent();
        }
    }
}