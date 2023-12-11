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
        //public virtual DbSet<SampleView> SampleViews { get; set; } = null!;

        protected void ViewModelBuilder(ref ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<SampleView>(entity =>
            {
                entity.HasNoKey();

				entity.ToView("SampleViews", "Schema");

				entity.Property(e => e.SamepleId)
				.HasColumnName("SameplId");

				entity.Property(e => e.SamepleCode)
				.HasMaxLength(10)
				.HasColumnName("SamepleCode");

			});
            */
        }
    }
}
