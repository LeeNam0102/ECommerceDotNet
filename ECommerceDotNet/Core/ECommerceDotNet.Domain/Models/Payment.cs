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
    [Table("Payment")]
    public class Payment
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        [Required]
        [StringLength(int.MaxValue)]
        public string PaymentType { get; set; }
        public virtual ICollection<UserPayment> UserPayments { get; set; }


        public Payment()
        {
            UserPayments = new HashSet<UserPayment>();
        }

    }
}
