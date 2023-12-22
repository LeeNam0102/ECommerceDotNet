using ECommerceDotNet.Common.Controllers;
using ECommerceDotNet.Common.Objects;
using ECommerceDotNet.Core.Application.DTOs.CasualDtos;
using ECommerceDotNet.Core.Application.DTOs.FilterDtos;
using ECommerceDotNet.Core.Application.DTOs.RequestDtos;
using ECommerceDotNet.Core.Application.Services;
using Microsoft.AspNetCore.Http;
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
    public class CategoryController:ApiControllerBase
    {
        #region Fields
        private readonly IConfiguration _config;
        private readonly ILogger _logger;
        private readonly ICategoryService _categoryService;
        #endregion

        #region Constructors
        public CategoryController(
            ILogger<RoleController> logger,
            IConfiguration configuration,
            ICategoryService categoryService)
        {
            _logger = logger;
            _config = configuration;
            _categoryService = categoryService;
        }
        #endregion

        #region Insert Category
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<CategoryDto?>> Insert([FromForm] CategoryBaseRequestDto categoryBaseRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            CategoryDto? categoryDto = await _categoryService.InsertCategoryAsync(categoryBaseRequestDto);
            categoryBaseRequestDto.SetUserID(await GetUserID());

            if (categoryDto != null)
            {
                return Ok(categoryDto);
            }

            return StatusCode(500);
        }
        #endregion

        #region Update Category
        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Update([FromForm] CategoryBaseRequestDto categoryBaseRequestDto, string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            categoryBaseRequestDto.SetUserID(await GetUserID());

            int total = await _categoryService.UpdateCategoryAsync(categoryBaseRequestDto, id);
            if (total > 0)
            {
                return Ok(total);
            }

            return StatusCode(500);
        }
        #endregion

        #region Delete Category
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(string id)
        {
            CategoryDto? categoryDto = await _categoryService.GetCategoryAsync(id, false);
            if (categoryDto == null)
            {
                return NotFound();
            }

            int total = await _categoryService.DeleteCategoryAsync(id);
            if (total > 0)
            {
                return Ok(total);
            }

            return StatusCode(500);
        }
        #endregion

        #region Get Role
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryBaseRequestDto?>> Get(string id, bool? isDeep)
        {
            CategoryDto? categoryDto = await _categoryService.GetCategoryAsync(id, isDeep ?? false);
            if (categoryDto == null)
            {
                return NotFound();
            }

            return Ok(categoryDto);
        }
        #endregion

        #region Get List Roles
        [HttpGet]
        public async Task<ActionResult<PagedDto<CategoryBaseRequestDto>>> GetList([FromQuery] CategoryFilterDto filterDto)
        {
            return Ok(await _categoryService.GetListCategoriesAsync(filterDto));
        }
        #endregion
    }
}

