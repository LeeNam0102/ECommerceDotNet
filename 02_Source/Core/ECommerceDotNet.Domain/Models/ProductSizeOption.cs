﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Core.Domain.Models
{
    [Table("ProductSizeOption")]
    public class ProductSizeOption
    {
        [Key]
        [Column(Order = 0)]
        [Required]
        [StringLength(450)]
        public string ProductId { get; set; }

        [Key]
        [Column(Order = 1)]
        [Required]
        [StringLength(255)]
        public string Size { get; set; }

        public virtual Product Product { get; set; } = null;

        public virtual SizeOption SizeOption { get; set; } = null;
    }
}
