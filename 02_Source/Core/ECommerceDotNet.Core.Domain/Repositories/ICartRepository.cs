using ECommerceDotNet.Common.Data;
using ECommerceDotNet.Common.Objects;
using ECommerceDotNet.Core.Domain.Filters;
using ECommerceDotNet.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Core.Domain.Repositories
{
    public interface ICartRepository : IRepository<Cart>
    {
        Task<Cart?> GetByIdAsync(string id, bool? isDeep = false);
        Task<PagedDto<Cart>> GetListAsync(CartFilter filter);
    }
}
