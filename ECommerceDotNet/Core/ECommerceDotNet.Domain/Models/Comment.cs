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
    [Table("Comment")]
    public class Comment
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public long ProductId { get; set; }

        [Required]
        public int AccountId { get; set; }

        public int? ParentCommentId { get; set; }

        [Required]
        public string CommentText { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public int  ParentComment { get; set; }

        public virtual ICollection<ProductComment> ProductComments { get; set; }
        public virtual ICollection<UserComment> UserComments { get; set; }


        public Comment()
        {
            ProductComments = new HashSet<ProductComment>();
            UserComments = new HashSet<UserComment>();
        }
    }
}
