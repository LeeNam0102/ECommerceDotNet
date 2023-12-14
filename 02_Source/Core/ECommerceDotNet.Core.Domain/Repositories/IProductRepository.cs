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
    public interface IProductRepository:IRepository<Product>
    {
        Task<Product?> GetByIdAsync(string id, bool? isDeep = false);
        Task<PagedDto<Product>> GetListAsync(ProductFilter filter);
    }
}
