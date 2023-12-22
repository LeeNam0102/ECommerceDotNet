using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Core.Application.DTOs.CasualDtos
{
    public class PaymentDto
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public int OrderId { get; set; }

        public string PaymentType { get; set; }
    }
}
