using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Core.Domain.Models
{
    [Table("SizeOption")]

    public class SizeOption
    {
        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string Size { get; set; }

        [Required]
        public int QuantityStock { get; set; }

        [Required]
        public int QuantitySold { get; set; }

        [StringLength(int.MaxValue)]
        public string Description { get; set; }

        public virtual ICollection<ProductSizeOption> ProductSizeOptions { get; set; }

        public SizeOption()
        {
            ProductSizeOptions = new HashSet<ProductSizeOption>();
        }
    }
}
