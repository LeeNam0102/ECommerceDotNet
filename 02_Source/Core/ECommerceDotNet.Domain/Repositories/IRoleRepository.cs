using ECommerceDotNet.Common.Objects;
using ECommerceDotNet.Core.Domain.Filters;
using ECommerceDotNet.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wata.Commerce.Common.Data;

namespace ECommerceDotNet.Core.Domain.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role?> GetByIdAsync(string id, bool? isDeep = false);
        Task<PagedDto<Role>> GetListAsync(RoleFilter filter);
    }
}
