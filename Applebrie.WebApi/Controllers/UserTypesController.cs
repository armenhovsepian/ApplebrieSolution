using Applebrie.Core.Dtos;
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
    public class UserTypesController : ControllerBase
    {
        private readonly IUserTypeRepository _userTypeRepository;
        private readonly IMapper _mapper;



        public UserTypesController(IUserTypeRepository userTypeRepository, IMapper mapper)
        {
            _userTypeRepository = userTypeRepository;
            _mapper = mapper;
        }


        // GET api/usertypes
        // GET api/usertypes?pagesize=3&pagenumber=1
        [HttpGet(Name = nameof(GetUserTypesAsync))]
        public async Task<ActionResult<IEnumerable<UserTypeDto>>> GetUserTypesAsync([FromQuery] PagingOptions pagingOptions, CancellationToken ct)
        {
            var userTypeSpec = new UserTypeFilterSpecification(pagingOptions.Take, pagingOptions.Skip);
            var userTypes = await _userTypeRepository.GetAllListAsync(userTypeSpec, ct);
            var data = userTypes.Select(ut => _mapper.Map<UserTypeDto>(ut));
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserTypeDto>> GetUserTypeAsync(int id, CancellationToken ct)
        {
            var data = await _userTypeRepository.GetByIdAsync(id, ct);

            if (data == null) return NotFound();

            return Ok(_mapper.Map<UserTypeDto>(data));
        }


        [HttpPost]
        public async Task<ActionResult> CreateUserTypeAsync([FromBody] UserTypeFormModel model, CancellationToken ct)
        {
            var userType = new UserType { Name = model.Name };

            await _userTypeRepository.AddAsync(userType, ct);

            return CreatedAtAction(nameof(GetUserTypeAsync), new { id = userType.Id }, userType);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserTypeAsync(int id, CancellationToken ct)
        {
            var userType = await _userTypeRepository.GetByIdAsync(id, ct);

            if (userType == null) return NotFound();

            await _userTypeRepository.DeleteAsync(userType, ct);

            return NoContent();
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserTypeAsync(int id, UserTypeFormModel model, CancellationToken ct)
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