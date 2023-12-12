using AutoMapper;
using ECommerceDotNet.Common.Objects;
using ECommerceDotNet.Core.Application.DTOs.CasualDtos;
using ECommerceDotNet.Core.Application.DTOs.FilterDtos;
using ECommerceDotNet.Core.Application.DTOs.RequestDtos;
using ECommerceDotNet.Core.Domain.Filters;
using ECommerceDotNet.Core.Domain.Models;
using ECommerceDotNet.Core.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace ECommerceDotNet.Core.Application.Services
{
    public class UserService : IUserService
    {
        #region Fields
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        protected readonly IUserRepository _userRepository;

        #endregion

        #region Constructors
        public UserService(
            ILogger<UserService> logger,
            IMapper mapper,
            IUserRepository userRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _userRepository = userRepository;
        
        }
        #endregion

        #region Insert User
        public async Task<UserDto?> InsertUserAsync(UserRequestDto dto)
        {
            string passwordHash = HashPassword(dto.Password);
            User user = new User();
            user.Id = Guid.NewGuid().ToString();
            user.Email = dto.Email;
            user.Password = passwordHash;
            user.Phone = dto.Phone;
            user.Username = dto.Email;
            user.Address= dto.Address;
            user.CreatedAt = dto.CreatedAt;
            user.IsActive = true;
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Avatar = dto.Avatar;
            user.Description = dto.Description;
            user.SecurityCode = dto.SecurityCode;

            User? newUser = await _userRepository.InsertAsync(user);
            if (newUser!=null)
            {
                return _mapper.Map<User, UserDto>(newUser);
            }
            _logger.LogError("User Create Fail");
            return null;
        }
        #endregion

        #region Update User
        public async Task<int> UpdateUserAsync(UserRequestDto dto, string id)
        {
            if (string.IsNullOrEmpty(id) || dto == null)
            {
                // Throw an exception or return an appropriate result for invalid input
                throw new ArgumentException("Invalid input parameters");
            }

            User? user = await _userRepository.GetByIdAsync(id);

            if (user != null)
            {
                user.Email = dto.Email;
                user.Username = dto.UserName;
                user.Phone = dto.Phone;

                return await _userRepository.UpdateAsync(user);
            }

            return 0;
        }
        #endregion

        #region Delete User
        public async Task<int> DeleteUserAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                // Throw an exception or return an appropriate result for invalid input
                throw new ArgumentException("Invalid user id");
            }

            return await _userRepository.DeleteAsync(id);
        }

        #endregion

        #region Get User
        public async Task<UserDto?> GetUserAsync(string id, bool isDeep = false)
        {
            if (string.IsNullOrEmpty(id))
            {
                // Throw an exception or return an appropriate result for invalid input
                throw new ArgumentException("Invalid user id");
            }

            User? user = await _userRepository.GetByIdAsync(id, isDeep);

            if (user != null)
            {
                return _mapper.Map<User, UserDto>(user);
            }

            return null;
        }

        #endregion

        #region Get List Users
        public async Task<PagedDto<UserDto>> GetListUsersAsync(UserFilterDto filterDto)
        {
            PagedDto<User> dt = await _userRepository.GetListAsync(_mapper.Map<UserFilterDto, UserFilter>(filterDto));

            List<UserDto> dtos = dt.Data.Select(item => _mapper.Map<User, UserDto>(item)).ToList();

            return new PagedDto<UserDto>(dt.TotalRecords, dtos);
        }

        #endregion

        #region Hash password
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        #endregion
    }

}
