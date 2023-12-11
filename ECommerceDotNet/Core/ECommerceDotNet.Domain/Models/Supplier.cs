using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Core.Domain.Models
{
    [Table("Supplier")]
    public class Supplier
    {
        [Key]
        [Required]
        [StringLength(450)]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public virtual ICollection<ProductSupplier> ProductSuppliers { get; set; }
        public Supplier()
        {
            ProductSuppliers = new HashSet<ProductSupplier>();
        }
    }
}
