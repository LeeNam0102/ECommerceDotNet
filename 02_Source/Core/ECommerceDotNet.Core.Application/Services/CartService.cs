using AutoMapper;
using ECommerceDotNet.Common.Objects;
using ECommerceDotNet.Core.Application.DTOs.CasualDtos;
using ECommerceDotNet.Core.Application.DTOs.FilterDtos;
using ECommerceDotNet.Core.Application.DTOs.RequestDtos;
using ECommerceDotNet.Core.Domain.Filters;
using ECommerceDotNet.Core.Domain.Models;
using ECommerceDotNet.Core.Domain.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Core.Application.Services
{
    public class CartService : ICartService
    {
        #region Fields
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        protected readonly ICartRepository _cartRepository;
        #endregion

        #region Constructors
        public CartService(
            ILogger<RoleService> logger,
            IMapper mapper,
            ICartRepository cartRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _cartRepository = cartRepository;

        }
        #endregion

        #region Delete Cart
        public async Task<int> DeleteCartAsync(string id)   
        {
            if (string.IsNullOrEmpty(id))
            {
                // Throw an exception or return an appropriate result for invalid input
                throw new ArgumentException("Invalid Role id");
                //return false;
            }
            return await _cartRepository.DeleteAsync(id);
        }
        #endregion

        #region Get Cart
        public async Task<CartDto?> GetCartAsync(string id, bool isDeep = false)
        {
            if (string.IsNullOrEmpty(id))
            {
                // Throw an exception or return an appropriate result for invalid input
                throw new ArgumentException("Invalid Cart id");
            }

            Cart? cart = await _cartRepository.GetByIdAsync(id, isDeep);

            if (cart != null)
            {
                return _mapper.Map<Cart, CartDto>(cart);
            }

            return null;
        }
        #endregion

        #region Get Carts List
        public async Task<PagedDto<CartDto>> GetListCartsAsync(CartFilterDto filterDto)
        {
            PagedDto<Cart> dt = await _cartRepository.GetListAsync(_mapper.Map<CartFilterDto, CartFilter>(filterDto));

            List<CartDto> dtos = dt.Data.Select(item => _mapper.Map<Cart, CartDto>(item)).ToList();

            return new PagedDto<CartDto>(dt.TotalRecords, dtos);
        }
        #endregion

        #region Insert Cart
        public async Task<CartDto?> InsertCartAsync(CartRequestDto requestDto)
        {
            Cart cart = new Cart();
            cart.Id = Guid.NewGuid().ToString();
            cart.CreatedAt = DateTime.Now;
            cart.CompletedAt = null;
            Cart newCart = await _cartRepository.InsertAsync(cart);
            if (newCart != null)
            {
                return _mapper.Map<CartDto>(newCart);
            }
            _logger.LogError("Cart Create Fail");
            return null;
        }
        #endregion

        #region Update Cart
        public async Task<int> UpdateCartAsync(CartBaseRequestDto requestDto, string id)
        {
            if (string.IsNullOrEmpty(id) || requestDto == null)
            {
                // Throw an exception or return an appropriate result for invalid input
                throw new ArgumentException("Invalid input parameters");
            }

            Cart? cart = await _cartRepository.GetByIdAsync(id);

            if (cart != null)
            {
                //cart.CompletedAt = requestDto?.CompletedAt;
                if (requestDto.status == 1)
                    cart.CompletedAt= DateTime.Now;
                else
                    cart.CompletedAt = null;
                return await _cartRepository.UpdateAsync(cart);
            }

            return 0;
        }
        #endregion
    }
}