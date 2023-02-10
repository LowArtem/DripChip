using System.Net.Mime;
using System.Security.Claims;
using DripChip.Core.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DripChip.Web.Controllers.Abstract;

[ApiController]
[Route("api/[controller]")]
[Authorize]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
public abstract class BaseApiController : ControllerBase
{
    /// <summary>
    /// Authorized user id
    /// </summary>
    /// <remarks>
    /// Result with ArgumentNullException if user is unauthorized
    /// <para></para>
    /// Result with ArgumentException if claim type is not integer
    /// </remarks>
    protected Result<int> UserId
    {
        get
        {
            var claim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if (claim is null)
            {
                return new ArgumentNullException(nameof(Claim), "User ID is null");
            }

            if (!int.TryParse(claim.Value, out var userId))
            {
                return new ArgumentException($"Cannot parse userId ({claim.Value}) to int");
            }

            return userId;
        }
    }
    
    /// <summary>
    /// Authorized user email
    /// </summary>
    /// <remarks>Result with ArgumentNullException if user is unauthorized</remarks>
    protected Result<string> UserEmail
    {
        get
        {
            var claim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
            if (claim is null)
            {
                return new ArgumentNullException(nameof(claim), "User login is null");
            }

            return claim.Value;
        }
    }
}