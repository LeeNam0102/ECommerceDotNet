using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Core.Domain.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [Required]
        [StringLength(450)]
        public string Id { get; set; }

        [StringLength(256)]
        public string Username { get; set; }

        [StringLength(4000)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [StringLength(256)]
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(256)]
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public bool IsActive { get; set; }
        public string SecurityCode { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<UserCollection> UserCollections { get; set; }
        public virtual ICollection<UserCart> UserCarts { get; set; }
        public virtual ICollection<UserComment> UserComments { get; set; }
        public virtual ICollection<UserPayment> UserPayments { get; set; }

        public virtual ICollection<UserOrder> UserOrders { get; set; }

        public User()
        {
            UserRoles = new HashSet<UserRole>();
            UserCollections = new HashSet<UserCollection>();
            UserPayments = new HashSet<UserPayment>();
            UserComments = new HashSet<UserComment>();
            UserCarts = new HashSet<UserCart>();
            UserOrders = new HashSet<UserOrder>();

        }
    }
}
