using DripChip.Core.Entities;
using DripChip.Core.Extensions;

namespace DripChip.Core.Services.Common;

public interface IUserService
{
    Task<Result<User?>> Authenticate(string email, string password);
}