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
            // Model to Dto
            #region Role
            CreateMap<Role, RoleDto>();
            #endregion

            #region User
            CreateMap<User, UserDto>();
            #endregion


            //Dto to Model
            #region User
            CreateMap<UserRequestDto, User>();
            #endregion
            #region UserFilter
            CreateMap<UserFilterDto, UserFilter>();
            #endregion
        }
    }
}
