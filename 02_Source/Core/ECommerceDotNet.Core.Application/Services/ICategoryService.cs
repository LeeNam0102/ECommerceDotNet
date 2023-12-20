using ECommerceDotNet.Common.Objects;
using ECommerceDotNet.Core.Application.DTOs.CasualDtos;
using ECommerceDotNet.Core.Application.DTOs.FilterDtos;
using ECommerceDotNet.Core.Application.DTOs.RequestDtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Core.Application.Services
{
    public interface ICategoryService
    {
        Task<CategoryDto?> InsertCategoryAsync(CategoryBaseRequestDto requestDto);
        Task<int> UpdateCategoryAsync(CategoryBaseRequestDto requestDto, string id);
        Task<int> DeleteCategoryAsync(string id);
        Task<CategoryDto?> GetCategoryAsync(string id, bool isDeep = false);
        Task<PagedDto<CategoryDto>> GetListCategoriesAsync(CategoryFilterDto filterDto);
        Task<string> UploadImage(IFormFile image);
    }
}
