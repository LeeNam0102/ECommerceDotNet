using ECommerceDotNet.Common.Objects;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Core.Application.DTOs.RequestDtos
{
    public class CategoryBaseRequestDto: RequestDtoBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IFormFile? Images { get; set; }

        //public DateTime? UpdatedAt { get; set; }
    }
}
