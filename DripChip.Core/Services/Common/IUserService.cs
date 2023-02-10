using DripChip.Core.Entities;

namespace DripChip.Core.Services.Common;

public interface IUserService
{
    Task<User?> AuthenticateAsync(string email, string password);
}