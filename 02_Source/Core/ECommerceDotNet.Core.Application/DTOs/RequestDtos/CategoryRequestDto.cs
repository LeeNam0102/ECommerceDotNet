using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Core.Application.DTOs.RequestDtos
{
    public class CategoryRequestDto:CategoryBaseRequestDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Images { get; set; }

        //public DateTime? UpdatedAt { get; set; }
    }
}
