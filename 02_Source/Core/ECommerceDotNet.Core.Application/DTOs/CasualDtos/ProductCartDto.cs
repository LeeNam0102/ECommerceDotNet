using ECommerceDotNet.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Core.Application.DTOs.CasualDtos
{
    public class ProductCartDto
    {
        public string ProductId { get; set; }

        public string CartId { get; set; }

        public string SizeOption { get; set; }

        public int Quantity { get; set; }
    }
}
