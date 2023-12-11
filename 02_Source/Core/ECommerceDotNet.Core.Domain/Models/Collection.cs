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
    [Table("Collection")]
    public class Collection
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    
        [Required]
        [StringLength(255)]
        public string SizeOption { get; set; }


        [StringLength(int.MaxValue)]
        public string Description { get; set; }

        public virtual ICollection<ProductCollection> ProductCollections { get; set; }
        public virtual ICollection<UserCollection> UserCollections { get; set; }

        public Collection()
        {
            ProductCollections = new HashSet<ProductCollection>();
            UserCollections = new HashSet<UserCollection>();
        }
    }
}
