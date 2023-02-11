using DripChip.Core.Entities;
using DripChip.Core.RequestDto;
using DripChip.Core.Services.Common;
using DripChip.Web.Controllers.Abstract;
using DripChip.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DripChip.Web.Controllers;

public class TestController : BaseApiController
{
    private readonly IUserService _userService;

    public TestController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Route("/time")]
    [AllowAnonymous]
    public ActionResult<string> GetCurrentUtcTime()
    {
        return Ok(DateTime.UtcNow);
    }

    [HttpPost]
    [Route("/registration")]
    [AllowAnonymous]
    public async Task<ActionResult<User>> Registration([FromBody] UserRequestDto.Registration user)
    {
        var result =  await _userService.Registration(user);
        return result.ToResponse();
    }
}