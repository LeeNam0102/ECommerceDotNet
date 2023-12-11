using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Core.Domain.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [Required]
        [StringLength(450)]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public float Price { get; set; }

        public string Description { get; set; }

        [Required]
        public string Image { get; set; }

        public string Summary { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public short Rating { get; set; } = 0;

        [StringLength(50)]
        public string Gender { get; set; }

        public virtual ICollection<ProductCategory> ProductCategorys { get; set; }
        public virtual ICollection<ProductDiscount> ProductDiscounts { get; set; }
        public virtual ICollection<ProductComment> ProductComments { get; set; }
        public virtual ICollection<ProductSupplier> ProductSuppliers { get; set; }

        public Product()
        {
            ProductCategorys = new HashSet<ProductCategory>();
            ProductDiscounts = new HashSet<ProductDiscount>();
            ProductSuppliers = new HashSet<ProductSupplier>();
            ProductComments = new HashSet<ProductComment>();
        }
    }
}
