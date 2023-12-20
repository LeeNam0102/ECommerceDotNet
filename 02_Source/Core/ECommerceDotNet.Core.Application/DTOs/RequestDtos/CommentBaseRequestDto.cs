using ECommerceDotNet.Common.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Core.Application.DTOs.RequestDtos
{
    public class CommentBaseRequestDto: RequestDtoBase
    {

        public long ProductId { get; set; }

        public int AccountId { get; set; }

        public int? ParentCommentId { get; set; }

        public string CommentText { get; set; }

        public int ParentComment { get; set; }
    }
}
