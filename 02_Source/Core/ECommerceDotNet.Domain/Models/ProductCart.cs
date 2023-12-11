using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Core.Domain.Models
{
    [Table("ProductCart")]
    public class ProductCart
    {
        [Key]
        [Column(Order = 0)]
        [Required]
        [StringLength(450)]
        public string ProductId { get; set; }

        [Key]
        [Column(Order = 1)]
        [Required]
        [StringLength(450)]
        public string CartId { get; set; }

        public virtual Product Product { get; set; } = null;

        public virtual Cart Cart { get; set; } = null;

        [Required]
        [StringLength(255)]
        public string SizeOption { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
