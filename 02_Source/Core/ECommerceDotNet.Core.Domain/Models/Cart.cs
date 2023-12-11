using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Core.Domain.Models
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        [Required]
        [StringLength(450)]
        public string Id { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? CompletedAt { get; set; }

        public virtual ICollection<UserCart> UserCarts { get; set; }
        public virtual ICollection<ProductCart> ProductCarts { get; set; }

        public Cart()
        {
            UserCarts = new HashSet<UserCart>();
            ProductCarts = new HashSet<ProductCart>();
        }
    }
}
