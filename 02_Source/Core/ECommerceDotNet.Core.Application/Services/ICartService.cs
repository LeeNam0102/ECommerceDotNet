using ECommerceDotNet.Common.Objects;
using ECommerceDotNet.Core.Application.DTOs.CasualDtos;
using ECommerceDotNet.Core.Application.DTOs.FilterDtos;
using ECommerceDotNet.Core.Application.DTOs.RequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Core.Application.Services
{
    public interface ICartService
    {
        Task<CartDto?> InsertCartAsync(CartRequestDto requestDto);
        Task<bool> UpdateCartAsync(CartRequestDto requestDto, string id);
        Task<bool> DeleteCartAsync(string id);
        Task<CartDto?> GetCartAsync(string id, bool isDeep = false);
        Task<PagedDto<CartDto>> GetListCartsAsync(CartFilterDto filterDto);
    }
}
