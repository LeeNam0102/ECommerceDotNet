using ECommerceDotNet.Common.Data;
using ECommerceDotNet.Common.Objects;
using ECommerceDotNet.Core.Domain.Filters;
using ECommerceDotNet.Core.Domain.Models;
using ECommerceDotNet.Core.Domain.Repositories;
using ECommerceDotNet.Infrastructure.Persistence.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Infrastructure.Persistence.Repositories
{
    public partial class UserRepository : AbstractEfRepository<ApplicationContext, User>, IUserRepository
    {
        public UserRepository(ApplicationContext db, ILogger<UserRepository> logger) : base(db, logger)
        {

        }

        private IQueryable<User> IncludeDeepObjects(IQueryable<User> query)
        {
            return query;
            //return query.Include(o => o.ReferTable);
            //return query.Include(o => o.UserRoles).ThenInclude(o => o.Role);
        }

        #region Get By Id
        public async Task<User?> GetByIdAsync(string id, bool? isDeep = false)
        {
            IQueryable<User> query = _db.Users;
            query = query.Where(o => o.Id == id);

            if (isDeep.Equals(true))
            {
                query = IncludeDeepObjects(query);
            }

            return await query.SingleOrDefaultAsync();
        }
        #endregion

        #region Get List
        public async Task<PagedDto<User>> GetListAsync(UserFilter filter)
        {
            int total = 0;
            IQueryable<User> query = _db.Users;

            //search
            if (filter.Keyword != null && filter.Keyword != "")
            {
                query = query.Where(ps => ps.Username.ToLower().Contains(filter.Keyword.ToLower()));
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
                    query = filter.IsDescending ? query.OrderByDescending(o => o.Username) : query.OrderBy(o => o.Username);
                    break;
            }
            query = query.Skip(filter.GetSkip()).Take(filter.GetTake());

            return new PagedDto<User>(total, await query.ToListAsync());
        }
        #endregion
    }
}
