using DripChip.Web.Controllers.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DripChip.Web.Controllers;

public class TestController : BaseApiController
{
    [HttpGet]
    [Route("/time")]
    public ActionResult<string> GetCurrentUtcTime()
    {
        return Ok(DateTime.UtcNow);
    }
}