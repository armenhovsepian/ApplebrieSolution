using Applebrie.Core.Dtos;
using Applebrie.Core.Entities;
using Applebrie.Core.Interfaces;
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
    /// <summary>
    /// https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.1&tabs=visual-studio
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class UserTypesController : ControllerBase
    {
        //private readonly IUserTypeService _userTypeService;
        private readonly IUserTypeRepository _userTypeRepository;
        private readonly IMapper _mapper;


        public UserTypesController(IUserTypeRepository userTypeRepository, IMapper mapper)
        {
            //_userTypeService = userTypeService;
            _userTypeRepository = userTypeRepository;
            _mapper = mapper;
        }


        // GET api/usertypes
        // GET api/usertypes?pagesize=3&pagenumber=1

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserTypeDto>>> GetUserTypes([FromQuery] PagingOptions pagingOptions, CancellationToken ct)
        {

            var userTypes = await _userTypeRepository.GetAllPagedListAsync(pagingOptions.Take, pagingOptions.Skip, ct);
            var data = userTypes.Select(ut => _mapper.Map<UserTypeDto>(ut));
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserTypeDto>> GetUserType(int id, CancellationToken ct)
        {
            var data = await _userTypeRepository.GetByIdAsync(id, ct);

            if (data == null) return NotFound();

            return Ok(_mapper.Map<UserTypeDto>(data));
        }


        [HttpPost]
        public async Task<ActionResult> CreateUserType([FromBody] UserTypeFormModel model, CancellationToken ct)
        {
            var userType = new UserType { Name = model.Name };

            await _userTypeRepository.AddAsync(userType, ct);

            return CreatedAtAction(nameof(GetUserType), new { id = userType.Id }, userType);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserType(int id, CancellationToken ct)
        {
            var userType = await _userTypeRepository.GetByIdAsync(id, ct);

            if (userType == null) return NotFound();

            await _userTypeRepository.DeleteAsync(userType, ct);

            return NoContent();
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserType(int id, UserTypeFormModel model, CancellationToken ct)
        {
            if (id != model.Id) return BadRequest();

            var userType = await _userTypeRepository.GetByIdAsync(id, ct);
            if (userType == null) return NotFound();

            userType.Name = model.Name;
            userType.Modified = DateTime.UtcNow;

            await _userTypeRepository.UpdateAsync(userType, ct);

            return NoContent();
        }
    }
}