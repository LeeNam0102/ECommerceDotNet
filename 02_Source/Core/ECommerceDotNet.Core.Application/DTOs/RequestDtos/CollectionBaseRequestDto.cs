using ECommerceDotNet.Common.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Core.Application.DTOs.RequestDtos
{
    public class CollectionBaseRequestDto : RequestDtoBase
    {
        public string SizeOption { get; set; }

        public string Description { get; set; }
    }
}
