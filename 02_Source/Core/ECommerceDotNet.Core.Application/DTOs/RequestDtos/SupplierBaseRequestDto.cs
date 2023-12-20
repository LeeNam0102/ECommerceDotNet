using ECommerceDotNet.Common.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Core.Application.DTOs.RequestDtos
{
    public class SupplierBaseRequestDto:RequestDtoBase
    {
        //public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
