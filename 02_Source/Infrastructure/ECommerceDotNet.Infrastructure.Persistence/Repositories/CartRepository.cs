﻿using ECommerceDotNet.Common.Data;
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
    public class CartRepository : AbstractEfRepository<ApplicationContext, Cart>, ICartRepository
    {
        public CartRepository(ApplicationContext db, ILogger<CartRepository> logger) : base(db, logger)
        {
        }

        private IQueryable<Cart> IncludeDeepObjects(IQueryable<Cart> query)
        {
            //return query.Include(o => o.ReferTable);
            //return query.Include(o => o.RolePermissionSet).ThenInclude(p => p.PermissionSet).Include(x => x.UserRole).ThenInclude(p => p.User);
            return query;
        }

        public async Task<Cart?> GetByIdAsync(string id, bool? isDeep = false)
        {
            IQueryable<Cart> query = _db.Carts;
            query = query.Where(o => o.Id == id);

            if (isDeep.Equals(true))
            {
                query = IncludeDeepObjects(query);
            }

            return await query.SingleOrDefaultAsync();
        }

        public async Task<PagedDto<Cart>> GetListAsync(CartFilter filter)
        {
            int total = 0;
            IQueryable<Cart> query = _db.Carts;
            // query where
            //if (filter.Keyword != null && filter.Keyword != "")
            //{
            //    query = query.Where(ps => ps.Name.ToLower().Contains(filter.Keyword.ToLower()));
            //}
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
                    query = filter.IsDescending ? query.OrderByDescending(o => o.CreatedAt) : query.OrderBy(o => o.CreatedAt);
                    break;
            }
            query = query.Skip(filter.GetSkip()).Take(filter.GetTake());

            return new PagedDto<Cart>(total, await query.ToListAsync());
        }
    }
}
