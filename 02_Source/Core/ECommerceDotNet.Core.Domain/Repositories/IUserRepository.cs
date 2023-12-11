using ECommerceDotNet.Common.Data;
using ECommerceDotNet.Common.Objects;
using ECommerceDotNet.Core.Domain.Filters;
using ECommerceDotNet.Core.Domain.Models;

namespace ECommerceDotNet.Core.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByIdAsync(string id, bool? isDeep = false);
        Task<PagedDto<User>> GetListAsync(UserFilter filter);

        //Task<User?> GetByEmailAsync(string email, bool? isDeep = false);
        //Task<User?> GetByPhoneNumberAsync(string phoneNumber, bool? isDeep = false);
        //Task<User?> GetByUsernameAsync(string username, bool? isDeep = false);
    }
}
