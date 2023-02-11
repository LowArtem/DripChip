using DripChip.Application.Dto;
using DripChip.Application.Mappers;
using DripChip.Core.Entities;
using DripChip.Core.Exceptions;
using DripChip.Core.Extensions;
using DripChip.Core.Interfaces;

namespace DripChip.Application.Services.Common;

public class UserService : IUserService
{
    private readonly IRepository<User, int> _userRepository;

    public UserService(IRepository<User, int> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<UserResponseDto.Info?>> Authenticate(UserRequestDto.Authenticate credentials)
    {
        if (string.IsNullOrEmpty(credentials.Email) || string.IsNullOrEmpty(credentials.Password))
        {
            return new ArgumentException("Credentials are null or empty");
        }

        var user = await Task.Run(() => _userRepository.Items.FirstOrDefault(
            u => u.Email == credentials.Email && u.Password == credentials.Password));
        return ApplicationMapper.Mapper.Map<UserResponseDto.Info>(user);
    }

    public async Task<Result<UserResponseDto.Info>> Registration(UserRequestDto.Registration user)
    {
        if (_userRepository.Items.Any(u => u.Email == user.Email))
        {
            return new EntityExistsException(nameof(User), user.Email);
        }

        var result = await _userRepository.AddAsync(ApplicationMapper.Mapper.Map<User>(user));
        return ApplicationMapper.Mapper.Map<UserResponseDto.Info>(result);
    }
}