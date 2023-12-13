using ECommerceDotNet.Common.Objects;
using ECommerceDotNet.Core.Application.DTOs.CasualDtos;
using ECommerceDotNet.Core.Application.DTOs.FilterDtos;
using ECommerceDotNet.Core.Application.DTOs.RequestDtos;

namespace ECommerceDotNet.Core.Application.Clients
{
    public interface IRoleClient
    {
        Task<RoleDto?> InsertAsync(RoleRequestDto requestDto);
        Task<int> UpdateAsync(RoleRequestDto requestDto, string id);
        Task<int> DeleteAsync(string id);
        Task<PagedDto<RoleDto>?> GetListAsync(RoleFilterDto filterDto);
    }
}
