using DripChip.Core.Entities;
using DripChip.Core.Extensions;
using DripChip.Core.RequestDto;

namespace DripChip.Core.Services.Common;

public interface IUserService
{
    Task<Result<User?>> Authenticate(UserRequestDto.Authenticate credentials);

    Task<Result<User>> Registration(UserRequestDto.Registration user);
}