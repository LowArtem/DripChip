﻿using DripChip.Core.Entities;
using DripChip.Core.Extensions;
using DripChip.Core.Interfaces;
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

    public async Task<Result<User?>> Authenticate(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            return new ArgumentException("Credentials are null or empty");
        }

        return await _userRepository.Items.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
    }
}