using DripChip.Web.Controllers.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DripChip.Web.Controllers;

public class TestController : BaseApiController
{
    [HttpGet]
    [Route("/time")]
    [AllowAnonymous]
    public ActionResult<string> GetCurrentUtcTime()
    {
        return Ok(DateTime.UtcNow);
    }
}