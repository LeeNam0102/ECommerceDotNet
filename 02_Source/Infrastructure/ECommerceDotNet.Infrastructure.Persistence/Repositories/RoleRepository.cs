using ECommerceDotNet.Common.Data;
using ECommerceDotNet.Common.Objects;
using ECommerceDotNet.Core.Domain.Filters;
using ECommerceDotNet.Core.Domain.Models;
using ECommerceDotNet.Core.Domain.Repositories;
using ECommerceDotNet.Infrastructure.Persistence.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ECommerceDotNet.Infrastructure.Persistence.Repositories
{
    public partial class RoleRepository : AbstractEfRepository<ApplicationContext, Role>, IRoleRepository
    {
        public RoleRepository(ApplicationContext db, ILogger<RoleRepository> logger) : base(db, logger)
        {

        }

        private IQueryable<Role> IncludeDeepObjects(IQueryable<Role> query)
        {
            //return query.Include(o => o.ReferTable);
            //return query.Include(o => o.RolePermissionSet).ThenInclude(p => p.PermissionSet).Include(x => x.UserRole).ThenInclude(p => p.User);
            return query;
        }

        #region Get By Id
        public async Task<Role?> GetByIdAsync(string id, bool? isDeep = false)
        {
            IQueryable<Role> query = _db.Roles;
            query = query.Where(o => o.Id == id);

            if (isDeep.Equals(true))
            {
                query = IncludeDeepObjects(query);
            }

            return await query.SingleOrDefaultAsync();
        }
        #endregion

        #region Get List
        public async Task<PagedDto<Role>> GetListAsync(RoleFilter filter)
        {
            int total = 0;
            IQueryable<Role> query = _db.Roles;
            // query where
            if (filter.Keyword != null && filter.Keyword != "")
            {
                query = query.Where(ps => ps.Name.ToLower().Contains(filter.Keyword.ToLower()));
            }
            if (filter.IsOutputTotal)
            {
                var queryCount = query.Select(o => o.Id);
                total = await queryCount.CountAsync();
            }

            if (filter.IsDeep.Equals(true))
            {
                query = IncludeDeepObjects(query);
            }

            switch (filter.OrderBy)
            {
                default:
                    query = filter.IsDescending ? query.OrderByDescending(o => o.Name) : query.OrderBy(o => o.Name);
                    break;
            }
            query = query.Skip(filter.GetSkip()).Take(filter.GetTake());

            return new PagedDto<Role>(total, await query.ToListAsync());
        }
        #endregion

    }
}
