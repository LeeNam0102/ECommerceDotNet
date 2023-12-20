using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Core.Application.DTOs.CasualDtos
{
    public class SizeOptionDto
    {
        public string Size { get; set; }

        public int QuantityStock { get; set; }

        public int QuantitySold { get; set; }

        public string Description { get; set; }
    }
}
