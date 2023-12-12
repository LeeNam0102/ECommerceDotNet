using ECommerceDotNet.Common.Objects;
using ECommerceDotNet.Core.Application.DTOs.CasualDtos;
using ECommerceDotNet.Core.Application.DTOs.FilterDtos;
using ECommerceDotNet.Core.Application.DTOs.RequestDtos;
namespace ECommerceDotNet.Core.Application.Services
{
    public interface IUserService
    {
        Task<UserDto?> InsertUserAsync(UserRequestDto requestDto);
        Task<int> UpdateUserAsync(UserRequestDto requestDto, string id);
        Task<int> DeleteUserAsync(string id);
        Task<UserDto?> GetUserAsync(string id, bool isDeep = false);
        Task<PagedDto<UserDto>> GetListUsersAsync(UserFilterDto filterDto);

    }
}
