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
    [Table("Order")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Đánh dấu khóa chính là tự động tăng
        public int Id { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [StringLength(255)]
        public string Status { get; set; }

        [Required]
        public float TotalPrice { get; set; }

        [Required]
        [StringLength(int.MaxValue)] 
        public string Address { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }
        public virtual ICollection<UserOrder> UserOrders { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }




    }
}