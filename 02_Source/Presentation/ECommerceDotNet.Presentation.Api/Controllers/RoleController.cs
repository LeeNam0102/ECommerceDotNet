using ECommerceDotNet.Common.Controllers;
using ECommerceDotNet.Common.Objects;
using ECommerceDotNet.Core.Application.DTOs.CasualDtos;
using ECommerceDotNet.Core.Application.DTOs.FilterDtos;
using ECommerceDotNet.Core.Application.DTOs.RequestDtos;
using ECommerceDotNet.Core.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Presentation.Api.Controllers
{
    [Route("api/Account/[controller]")]
    [ApiController]
    public class RoleController : ApiControllerBase
    {
        #region Fields
        private readonly IConfiguration _config;
        private readonly ILogger _logger;
        private readonly IRoleService _roleService;
        #endregion

        #region Constructors
        public RoleController(
            ILogger<RoleController> logger,
            IConfiguration configuration,
            IRoleService roleService)
        {
            _logger = logger;
            _config = configuration;
            _roleService = roleService;
        }
        #endregion

        #region Insert Role
        [HttpPost]
        public async Task<ActionResult<RoleDto?>> Insert([FromBody] RoleRequestDto roleRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            RoleDto? roleDto = await _roleService.InsertRoleAsync(roleRequestDto);
            roleRequestDto.SetUserID(await GetUserID());

            if (roleDto != null)
            {
                return Ok(roleDto);
            }

            return StatusCode(500);
        }
        #endregion

        #region Update Role
        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Update([FromBody] RoleRequestDto roleRequestDto, string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            roleRequestDto.SetUserID(await GetUserID());

            int total = await _roleService.UpdateRoleAsync(roleRequestDto, id);
            if (total > 0)
            {
                return Ok(total);
            }

            return StatusCode(500);
        }
        #endregion

        #region Delete Role
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(string id)
        {
            RoleDto? roleDto = await _roleService.GetRoleAsync(id, false);
            if (roleDto == null)
            {
                return NotFound();
            }

            int total = await _roleService.DeleteRoleAsync(id);
            if (total > 0)
            {
                return Ok(total);
            }

            return StatusCode(500);
        }
        #endregion

        #region Get Role
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDto?>> Get(string id, bool? isDeep)
        {
            RoleDto? roleDto = await _roleService.GetRoleAsync(id, isDeep ?? false);
            if (roleDto == null)
            {
                return NotFound();
            }

            return Ok(roleDto);
        }
        #endregion

        #region Get List Roles
        [HttpGet]
        public async Task<ActionResult<PagedDto<RoleDto>>> GetList([FromQuery] RoleFilterDto filterDto)
        {
            return Ok(await _roleService.GetListRolesAsync(filterDto));
        }
        #endregion
    }
}