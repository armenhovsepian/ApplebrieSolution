﻿using Applebrie.Core.Dtos;
using Applebrie.Core.Entities;
using Applebrie.Core.Interfaces;
using Applebrie.Core.Specifications;
using Applebrie.WebApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        // GET api/users
        // GET api/users?pagesize=3&pagenumber=1
        // GET api/users?usertypeid=1
        // GET api/users?pagesize=3&pagenumber=1&usertypeid=1
        [HttpGet(Name = nameof(GetUsersAsync))]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsersAsync(
            [FromQuery] PagingOptions pagingOptions,
            [FromQuery] SearchOptions searchOptions,
            CancellationToken ct)
        {
            var userSpec = new UserFilterSpecification(pagingOptions.Skip, pagingOptions.Take, searchOptions.UserTypeId);
            var users = await _userRepository.GetAllListAsync(userSpec, ct);
            var userDtos = users.Select(user => _mapper.Map<UserDto>(user));
            return Ok(userDtos);
        }


        [HttpGet("{id}", Name = nameof(GetUserAsync))]
        public async Task<ActionResult<UserDto>> GetUserAsync(int id, CancellationToken ct)
        {
            var data = await _userRepository.GetByIdWithUserTypeAsync(id, ct);

            if (data == null) return NotFound();

            return Ok(_mapper.Map<UserDto>(data));
        }


        [HttpPost]
        public async Task<ActionResult> CreateUserAsync([FromBody] UserFormModel model, CancellationToken ct)
        {
            var userType = await _userTypeRepository.GetByIdAsync(model.UserType.Id, ct);
            if (userType == null) return BadRequest(new ApiError("UserType Id is invalid!"));

            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserTypeId = userType.Id

            };
            await _userRepository.AddAsync(user, ct);

            return CreatedAtAction(nameof(GetUserAsync), new { id = user.Id }, user);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(int id, CancellationToken ct)
        {
            var user = await _userRepository.GetByIdAsync(id, ct);

            if (user == null) return NotFound();

            await _userRepository.DeleteAsync(user, ct);

            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAsync(int id, UserFormModel model, CancellationToken ct)
        {
            if (id != model.Id) return BadRequest();

            var userType = await _userTypeRepository.GetByIdAsync(model.UserType.Id, ct);
            if (userType == null) return BadRequest(new ApiError { Message = "UserType Id is wrong!" });

            var user = await _userRepository.GetByIdAsync(id, ct);
            if (user == null) return NotFound();

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.UserTypeId = userType.Id;
            user.Modified = DateTime.UtcNow;

            await _userTypeRepository.UpdateAsync(userType, ct);

            return NoContent();
        }
    }
}