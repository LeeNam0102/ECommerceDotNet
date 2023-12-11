using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Core.Domain.Models
{
    [Table("Role")]
    public class Role
    {
        [Key]
        [Required]
        [StringLength(450)]
        public string Id { get; set; }


        [StringLength(256)]
        public string? Name { get; set; }

        [StringLength(256)]
        public string? Description { get; set; }

        public virtual ICollection<UserRole> UserRole { get; set; }


        public Role()
        {
            UserRole = new HashSet<UserRole>();
        }
    }
}