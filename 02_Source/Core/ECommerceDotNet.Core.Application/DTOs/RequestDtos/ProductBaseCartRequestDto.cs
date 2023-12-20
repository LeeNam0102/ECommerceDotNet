using ECommerceDotNet.Common.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Core.Application.DTOs.RequestDtos
{
    public class ProductBaseCartRequestDto:RequestDtoBase
    {
        public string ProductId { get; set; }

        public string CartId { get; set; }

        public string SizeOption { get; set; }

        public int Quantity { get; set; }
    }
}
