using DripChip.Application.Dto;
using DripChip.Core.Entities;
using DripChip.Core.Extensions;

namespace DripChip.Application.Services.Common;

public interface IUserService
{
    Task<Result<UserResponseDto.Info?>> Authenticate(UserRequestDto.Authenticate credentials);

    Task<Result<UserResponseDto.Info>> Registration(UserRequestDto.Registration user);
}