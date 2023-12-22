using ECommerceDotNet.Common.Controllers;
using ECommerceDotNet.Common.Objects;
using ECommerceDotNet.Core.Application.DTOs.CasualDtos;
using ECommerceDotNet.Core.Application.DTOs.FilterDtos;
using ECommerceDotNet.Core.Application.DTOs.RequestDtos;
using ECommerceDotNet.Core.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Presentation.Api.Controllers
{
    [Route("api/Account/[controller]")]
    [ApiController]
    public class CartController : ApiControllerBase
    {
        #region Fields
        private readonly IConfiguration _config;
        private readonly ILogger _logger;
        private readonly ICartService _cartService;
        #endregion

        #region Constructors
        public CartController(
            ILogger<RoleController> logger,
            IConfiguration configuration,
            ICartService cartService)
        {
            _logger = logger;
            _config = configuration;
            _cartService = cartService;
        }
        #endregion

        #region Insert Cart
        [HttpPost]
        public async Task<ActionResult<CartDto?>> Insert([FromBody] CartRequestDto cartRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            CartDto? cartDto = await _cartService.InsertCartAsync(cartRequestDto);
            cartRequestDto.SetUserID(await GetUserID());

            if (cartDto != null)
            {
                return Ok(cartDto);
            }

            return StatusCode(500);
        }
        #endregion

        #region Update Cart
        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Update([FromBody] CartBaseRequestDto cartRequestDto, string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            cartRequestDto.SetUserID(await GetUserID());

            int total = await _cartService.UpdateCartAsync(cartRequestDto, id);
            if (total > 0)
            {
                return Ok(total);
            }

            return StatusCode(500);
        }
        #endregion

        #region Delete Role
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(string id)
        {
            CartDto? cartDto = await _cartService.GetCartAsync(id, false);
            if (cartDto == null)
            {
                return NotFound();
            }

            int total = await _cartService.DeleteCartAsync(id);
            if (total > 0)
            {
                return Ok(total);
            }

            return StatusCode(500);
        }
        #endregion

        #region Get Role
        [HttpGet("{id}")]
        public async Task<ActionResult<CartDto?>> Get(string id, bool? isDeep)
        {
            CartDto? cartDto = await _cartService.GetCartAsync(id, isDeep ?? false);
            if (cartDto == null)
            {
                return NotFound();
            }

            return Ok(cartDto);
        }
        #endregion

        #region Get List Roles
        [HttpGet]
        public async Task<ActionResult<PagedDto<CartDto>>> GetList([FromQuery] CartFilterDto filterDto)
        {
            return Ok(await _cartService.GetListCartsAsync(filterDto));
        }
        #endregion
    }
}