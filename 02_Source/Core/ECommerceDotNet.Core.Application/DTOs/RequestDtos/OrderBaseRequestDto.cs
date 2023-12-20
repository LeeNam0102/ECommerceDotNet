using ECommerceDotNet.Common.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Core.Application.DTOs.RequestDtos
{
    public class OrderBaseRequestDto: RequestDtoBase
    {

        //public DateTime OrderDate { get; set; }

        public string Status { get; set; }

        public float TotalPrice { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }
    }
}
