using DripChip.Core.Entities;
using DripChip.Core.Extensions;
using DripChip.Core.Interfaces;
using DripChip.Core.RequestDto;
using DripChip.Core.Services.Common;
using Microsoft.EntityFrameworkCore;

namespace DripChip.Infrastructure.Services.Common;

public class UserService : IUserService
{
    private readonly IRepository<User, int> _userRepository;

    public UserService(IRepository<User, int> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<User?>> Authenticate(UserRequestDto.Authenticate credentials)
    {
        if (string.IsNullOrEmpty(credentials.Email) || string.IsNullOrEmpty(credentials.Password))
        {
            return new ArgumentException("Credentials are null or empty");
        }

        return await _userRepository.Items.FirstOrDefaultAsync(u =>
            u.Email == credentials.Email && u.Password == credentials.Password);
    }

    public Task<Result<User?>> Registration(UserRequestDto.Registration user)
    {
        throw new NotImplementedException();
    }
}