using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Common.Objects
{
    public class ModelBase
    {
        [Required]
        [StringLength(36)]
        public string Id { get; set; }
    }
}
