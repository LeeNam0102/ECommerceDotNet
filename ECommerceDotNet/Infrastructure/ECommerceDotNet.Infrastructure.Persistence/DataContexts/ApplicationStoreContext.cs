using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Infrastructure.Persistence.DataContexts
{
    public partial class ApplicationContext : DbContext
    {
        //public virtual DbSet<AbcResult> AbcResults { get; set; } = null!;

        protected void StoreModelBuilder(ref ModelBuilder modelBuilder)
        {
            /*
			modelBuilder.Entity<AbcResult>(entity =>
			{
				entity.HasNoKey();
			});
			*/
        }
    }
}
