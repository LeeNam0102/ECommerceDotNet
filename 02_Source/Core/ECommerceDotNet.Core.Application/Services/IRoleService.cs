using ECommerceDotNet.Common.Objects;
using ECommerceDotNet.Core.Application.DTOs.CasualDtos;
using ECommerceDotNet.Core.Application.DTOs.FilterDtos;
using ECommerceDotNet.Core.Application.DTOs.RequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Core.Application.Services
{
    public interface IRoleService
    {
        Task<RoleDto?> InsertRoleAsync(RoleRequestDto requestDto);
        Task<int> UpdateRoleAsync(RoleRequestDto requestDto, string id);
        Task<int> DeleteRoleAsync(string id);
        Task<RoleDto?> GetRoleAsync(string id, bool isDeep = false);
        Task<PagedDto<RoleDto>> GetListRolesAsync(RoleFilterDto filterDto);
    }
}
