using ECommerceDotNet.Common.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Core.Application.DTOs.RequestDtos
{
    public class SizeOptionBaseRequestDto:RequestDtoBase
    {
        public string Size { get; set; }

        public int QuantityStock { get; set; }

        public int QuantitySold { get; set; }

        public string Description { get; set; }
    }
}
