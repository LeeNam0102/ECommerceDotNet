using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Core.Domain.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [Required]
        [StringLength(450)]
        public string Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string Images { get; set; }

        public DateTime? CreatedAt { get; set; }


        public DateTime? UpdatedAt { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
        public Category()
        {
            ProductCategories = new HashSet<ProductCategory>();
        }
    }
}
