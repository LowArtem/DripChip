using Microsoft.AspNetCore.Mvc;

namespace DripChip.Web.Extensions;

/// <summary>
/// An <see cref="ObjectResult"/> that when executed performs content negotiation, formats the entity body, and
/// will produce a <see cref="StatusCodes.Status201Created"/> response if negotiation and formatting succeed.
/// </summary>
public class CreatedObjectResult : ObjectResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreatedObjectResult"/> class.
    /// </summary>
    /// <param name="value">The content to format into the entity body.</param>
    public CreatedObjectResult(object? value) : base(value)
    {
        StatusCode = StatusCodes.Status201Created;
    }
}