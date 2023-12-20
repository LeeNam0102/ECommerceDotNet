using ECommerceDotNet.Common.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Core.Application.DTOs.RequestDtos
{
    public class DiscountBaseRequestDto:RequestDtoBase
    {
        public float Percent { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
