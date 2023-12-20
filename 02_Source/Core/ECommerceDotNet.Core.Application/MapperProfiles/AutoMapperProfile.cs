using AutoMapper;
using ECommerceDotNet.Core.Application.DTOs.CasualDtos;
using ECommerceDotNet.Core.Application.DTOs.FilterDtos;
using ECommerceDotNet.Core.Application.DTOs.RequestDtos;
using ECommerceDotNet.Core.Domain.Filters;
using ECommerceDotNet.Core.Domain.Models;

namespace Wata.Commerce.Account.Business.MapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Model to Dto
            #region Role
            CreateMap<Role, RoleDto>();
            #endregion

            #region User
            CreateMap<User, UserDto>();
            #endregion

            #region Cart
            CreateMap<Cart, CartDto>();
            #endregion

            #region Category
            CreateMap<Category, CategoryDto>();
            #endregion

            //Dto to Model
            #region User
            CreateMap<UserRequestDto, User>();
            #endregion

            #region Role
            CreateMap<RoleRequestDto, Role>();
            #endregion

            #region Cart
            CreateMap<CartBaseRequestDto,Cart>();
            #endregion

            #region Category
            CreateMap<CategoryRequestDto, Category>();
            #endregion

            //Filter
            #region UserFilter
            CreateMap<UserFilterDto, UserFilter>();
            #endregion

            #region RoleFilter
            CreateMap<RoleFilterDto, RoleFilter>();
            #endregion
            #region CartFilter
            CreateMap<CartFilterDto, CartFilter>();
            #endregion

            #region CategoryFilter
            CreateMap<CategoryFilterDto, CategoryFilter>();
            #endregion
        }
    }
}
