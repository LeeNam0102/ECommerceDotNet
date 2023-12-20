using ECommerceDotNet.Common.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Core.Application.DTOs.RequestDtos
{
    public class PaymentBaseRequestDto: RequestDtoBase
    {
        //public int Id { get; set; }

        //public DateTime Created { get; set; }

        public int OrderId { get; set; }

        public string PaymentType { get; set; }
    }
}
