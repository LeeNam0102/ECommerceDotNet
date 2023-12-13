using AutoMapper;
using ECommerceDotNet.Common.Objects;
using ECommerceDotNet.Core.Application.DTOs.CasualDtos;
using ECommerceDotNet.Core.Application.DTOs.FilterDtos;
using ECommerceDotNet.Core.Application.DTOs.RequestDtos;
using ECommerceDotNet.Core.Domain.Filters;
using ECommerceDotNet.Core.Domain.Models;
using ECommerceDotNet.Core.Domain.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Core.Application.Services
{
    public class RoleService : IRoleService
    {
        #region Fields
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        protected readonly IRoleRepository _roleRepository;
        #endregion

        #region Constructors
        public RoleService(
            ILogger<RoleService> logger,
            IMapper mapper,
            IRoleRepository roleRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _roleRepository = roleRepository;

        }
        #endregion

        #region Insert Role
        public async Task<RoleDto?> InsertRoleAsync(RoleRequestDto dto)
        {
            Role role = new Role();
            role.Id = Guid.NewGuid().ToString();
            role.Name = dto.Name;
            role.Description = dto.Description;
            Role? newRole = await _roleRepository.InsertAsync(role);
            if (newRole != null)
            {
                return _mapper.Map<Role, RoleDto>(newRole);
            }
            _logger.LogError("Role Create Fail");
            return null;
        }
        #endregion

        #region Update Role
        public async Task<int> UpdateRoleAsync(RoleRequestDto dto, string id)
        {
            if (string.IsNullOrEmpty(id) || dto == null)
            {
                // Throw an exception or return an appropriate result for invalid input
                throw new ArgumentException("Invalid input parameters");
            }

            Role? role = await _roleRepository.GetByIdAsync(id);

            if (role != null)
            {
                role.Name = dto?.Name;

                return await _roleRepository.UpdateAsync(role);
            }

            return 0;
        }
        #endregion

        #region Delete Role
        public async Task<int> DeleteRoleAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                // Throw an exception or return an appropriate result for invalid input
                throw new ArgumentException("Invalid Role id");
            }

            return await _roleRepository.DeleteAsync(id);
        }

        #endregion

        #region Get Role
        public async Task<RoleDto?> GetRoleAsync(string id, bool isDeep = false)
        {
            if (string.IsNullOrEmpty(id))
            {
                // Throw an exception or return an appropriate result for invalid input
                throw new ArgumentException("Invalid Role id");
            }

            Role? role = await _roleRepository.GetByIdAsync(id, isDeep);

            if (role != null)
            {
                return _mapper.Map<Role, RoleDto>(role);
            }

            return null;
        }

        #endregion

        #region Get List Roles
        public async Task<PagedDto<RoleDto>> GetListRolesAsync(RoleFilterDto filterDto)
        {
            PagedDto<Role> dt = await _roleRepository.GetListAsync(_mapper.Map<RoleFilterDto, RoleFilter>(filterDto));

            List<RoleDto> dtos = dt.Data.Select(item => _mapper.Map<Role, RoleDto>(item)).ToList();

            return new PagedDto<RoleDto>(dt.TotalRecords, dtos);
        }
        #endregion
    }
}
