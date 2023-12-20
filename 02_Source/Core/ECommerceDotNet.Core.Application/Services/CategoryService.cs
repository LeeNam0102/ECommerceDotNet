using AutoMapper;
using ECommerceDotNet.Common.Objects;
using ECommerceDotNet.Core.Application.DTOs.CasualDtos;
using ECommerceDotNet.Core.Application.DTOs.FilterDtos;
using ECommerceDotNet.Core.Application.DTOs.RequestDtos;
using ECommerceDotNet.Core.Domain.Filters;
using ECommerceDotNet.Core.Domain.Models;
using ECommerceDotNet.Core.Domain.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ECommerceDotNet.Core.Application.Services
{
    public class CategoryService : ICategoryService
    {
        #region Fields
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        protected readonly ICategoryRepository _categoryRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        #endregion

        #region Constructors
        public CategoryService(
            ILogger<CategoryService> logger,
            IMapper mapper,
            ICategoryRepository categoryRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        #endregion

        #region Delete Category
        public async Task<int> DeleteCategoryAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Invalid Category id");
            }
            await DeleteImage(id);
            return await _categoryRepository.DeleteAsync(id);
        }

        public async Task DeleteImage(string id)
        {
            Category category = await _categoryRepository.GetByIdAsync(id);
            var fullPath = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot", category.Images);
            if (File.Exists(fullPath))
            {
                await Task.Run(() => File.Delete(fullPath));
            }
        }
        #endregion

        #region Get Category
        public async Task<CategoryDto?> GetCategoryAsync(string id, bool isDeep = false)
        {
            if (string.IsNullOrEmpty(id))
            {
                // Throw an exception or return an appropriate result for invalid input
                throw new ArgumentException("Invalid Cart id");
            }

            Category? category = await _categoryRepository.GetByIdAsync(id, isDeep);

            if (category != null)
            {
                return _mapper.Map<Category, CategoryDto>(category);
            }

            return null;
        }
        #endregion

        #region Get Categories List
        public async Task<PagedDto<CategoryDto>> GetListCategoriesAsync(CategoryFilterDto filterDto)
        {
            PagedDto<Category> dt = await _categoryRepository.GetListAsync(_mapper.Map<CategoryFilterDto, CategoryFilter>(filterDto));

            List<CategoryDto> dtos = dt.Data.Select(item => _mapper.Map<Category, CategoryDto>(item)).ToList();

            return new PagedDto<CategoryDto>(dt.TotalRecords, dtos);
        }
        #endregion

        #region Insert Category
        public async Task<CategoryDto?> InsertCategoryAsync(CategoryBaseRequestDto requestDto)
        {
            Category category = new Category();
            category.Id = Guid.NewGuid().ToString();
            category.CreatedAt = DateTime.Now;
            category.UpdatedAt = null;
            category.Name = requestDto.Name;
            category.Description = requestDto.Description;
            category.Images = await UploadImage(requestDto.Images);
            Category newCategory = await _categoryRepository.InsertAsync(category);
            if (newCategory != null)
            {
                return _mapper.Map<CategoryDto>(newCategory);
            }
            _logger.LogError("Category Create Fail");
            return null;
        }

        public async Task<string> UploadImage(IFormFile image)
        {
            if (image == null || image.Length == 0)
                throw new ArgumentException("Invalid file");

            var uploads = Path.Combine(_webHostEnvironment.ContentRootPath,  "wwwroot", "Images");

            if (!Directory.Exists(uploads))
                Directory.CreateDirectory(uploads);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            var filePath = Path.Combine(uploads, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            return Path.Combine("Images", fileName);
            // khi lấy ảnh thì xài <img ...src="/@category.Images" ...> để lấy ảnh (có lẽ v ¯\_(ツ)_/¯ )
        }
        #endregion

        #region Update Category
        public async Task<int> UpdateCategoryAsync(CategoryBaseRequestDto requestDto, string id)
        {
            if (string.IsNullOrEmpty(id) || requestDto == null)
            {
                throw new ArgumentException("Invalid input parameters");
            }
            Category oldCategory = await _categoryRepository.GetByIdAsync(id);
            if (oldCategory != null)
            {
                oldCategory.Name = requestDto.Name;
                oldCategory.Description = requestDto.Description;
                oldCategory.UpdatedAt = DateTime.Now;
                if (requestDto.Images != null)
                {
                    await DeleteImage(id);
                    oldCategory.Images = await UploadImage(requestDto.Images);
                    return await _categoryRepository.UpdateAsync(oldCategory);
                }
            }
            return 0;
        } 
        #endregion

    }
}
