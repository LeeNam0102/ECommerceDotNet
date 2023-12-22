using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Core.Application.DTOs.CasualDtos
{
    public class CommentDto
    {
        public int Id { get; set; }

        public long ProductId { get; set; }

        public int AccountId { get; set; }

        public int? ParentCommentId { get; set; }

        public string CommentText { get; set; }

        public DateTime CreateDate { get; set; }

        public int ParentComment { get; set; }
    }
}
