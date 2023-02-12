using DripChip.Application.Dto;
using DripChip.Core.Extensions;

namespace DripChip.Application.Services.Common;

public interface IUserService
{
    Task<Result<UserResponseDto.Info?>> Authenticate(UserRequestDto.Authenticate credentials);

    Task<Result<UserResponseDto.Info>> Registration(UserRequestDto.AccountManagement user);

    Task<Result<UserResponseDto.Info>> GetInfo(int accountId);

    Result<List<UserResponseDto.Info>> SearchUser(UserRequestDto.Search prompt);

    Task<Result<UserResponseDto.Info>> UpdateAccount(int accountId, UserRequestDto.AccountManagement newData);

    Task<Result> DeleteAccount(int accountId);
}