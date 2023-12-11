using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Core.Domain.Models
{
    [Table("UserPayment")]
    public class UserPayment
    {
        [Key]
        [Column(Order = 0)]
        [Required]
        [StringLength(450)]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        [Required]
        [StringLength(450)]
        public int PaymentId { get; set; }

        public virtual User User { get; set; } = null;

        public virtual Payment Payment { get; set; } = null;
    }
}
