using DripChip.Application.Dto;
using DripChip.Application.Services.Common;
using DripChip.Core.Exceptions;
using DripChip.Core.Extensions;
using DripChip.Web.Controllers.Abstract;
using DripChip.Web.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DripChip.Web.Controllers;

public class AuthController : BaseApiController
{
    private readonly IUserService _userService;
    private readonly IValidator<UserRequestDto.AccountManagement> _accountValidator;

    public AuthController(IUserService userService, IValidator<UserRequestDto.AccountManagement> accountValidator)
    {
        _userService = userService;
        _accountValidator = accountValidator;
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("/registration")]
    public async Task<ActionResult<UserResponseDto.Info>> Registration(
        [FromBody] UserRequestDto.AccountManagement account)
    {
        if (UserId.IsSuccess)
            return Result.Fail(new AccountAccessException("You already registered")).ToResponse();

        var validationResult = await _accountValidator.ValidateAsync(account);
        if (!validationResult.IsValid)
            return validationResult.ToResult().ToResponse();

        var registered = await _userService.Registration(account);
        return registered.ToResponse();
    }
}