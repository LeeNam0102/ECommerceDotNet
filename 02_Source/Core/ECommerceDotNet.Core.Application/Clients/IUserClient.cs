using ECommerceDotNet.Common.Objects;
using ECommerceDotNet.Core.Application.DTOs.CasualDtos;
using ECommerceDotNet.Core.Application.DTOs.FilterDtos;
using ECommerceDotNet.Core.Application.DTOs.RequestDtos;

namespace ECommerceDotNet.Core.Application.Clients
{
    public interface IUserClient
    {
        Task<UserDto?> InsertAsync(UserRequestDto requestDto);
        Task<int> UpdateAsync(UserRequestDto requestDto, string id);
        Task<int> DeleteAsync(string id);
        Task<PagedDto<UserDto>?> GetListAsync(UserFilterDto filterDto);
    }
}
