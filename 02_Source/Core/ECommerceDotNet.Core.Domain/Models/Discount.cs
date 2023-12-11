using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Core.Domain.Models
{
    [Table("Discount")]
    public class Discount
    {
        [Key]
        [Required]
        [StringLength(450)]
        public string Id { get; set; }

        [Required]
        public float Percent { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }
        public virtual ICollection<ProductDiscount> ProductDiscounts { get; set; }
        public Discount()
        {
            ProductDiscounts = new HashSet<ProductDiscount>();
        }
    }
}
