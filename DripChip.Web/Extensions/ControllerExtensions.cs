using System.ComponentModel.DataAnnotations;
using System.Security.Authentication;
using DripChip.Core.Exceptions;
using DripChip.Core.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DripChip.Web.Extensions;

public enum ResponseStatus
{
    STATUS200_OK,
    STATUS201_CREATED
}

public static class ControllerExtensions
{
    public static ActionResult<T> ToResponse<T>(this Result<T> result,
        ResponseStatus responseStatus = ResponseStatus.STATUS200_OK)
    {
        if (result.IsSuccess)
        {
            if (responseStatus == ResponseStatus.STATUS200_OK)
                return new OkObjectResult(result.Value);
            else
                return new CreatedObjectResult(result.Value);
        }

        return ConvertToActionResult(result);
    }

    public static ActionResult<TResponse> ToResponse<TData, TResponse>(this Result<TData> result,
        Func<TData, TResponse> mapper, ResponseStatus responseStatus = ResponseStatus.STATUS200_OK)
    {
        if (result.IsSuccess)
        {
            var response = mapper(result.Value);

            if (responseStatus == ResponseStatus.STATUS200_OK)
                return new OkObjectResult(response);
            else
                return new CreatedObjectResult(response);
        }

        return ConvertToActionResult(result);
    }

    public static ActionResult ToResponse(this Result result)
    {
        if (result.IsSuccess)
        {
            return new OkResult();
        }

        return ConvertToActionResult(result);
    }


    // These two methods must have the same implementation

    private static ActionResult ConvertToActionResult<T>(Result<T> result)
    {
        return result.Exception switch
        {
            EntityExistsException => new ConflictObjectResult(result.Exception.Message),
            EntityNotFoundException => new NotFoundObjectResult(result.Exception.Message),
            ArgumentNullException => new BadRequestObjectResult(result.Exception.Message),
            ValidationException => new BadRequestObjectResult(result.Exception.Message),
            AuthenticationException => new UnauthorizedObjectResult(result.Exception.Message),
            AccountAccessException => new ContentResult { StatusCode = 403, Content = result.Exception!.Message },
            _ => new ContentResult { StatusCode = 500, Content = result.Exception!.Message }
        };
    }

    private static ActionResult ConvertToActionResult(Result result)
    {
        return result.Exception switch
        {
            EntityExistsException => new ConflictObjectResult(result.Exception.Message),
            EntityNotFoundException => new NotFoundObjectResult(result.Exception.Message),
            ArgumentNullException => new BadRequestObjectResult(result.Exception.Message),
            ValidationException => new BadRequestObjectResult(result.Exception.Message),
            AuthenticationException => new UnauthorizedObjectResult(result.Exception.Message),
            AccountAccessException => new ContentResult { StatusCode = 403, Content = result.Exception!.Message },
            _ => new ContentResult { StatusCode = 500, Content = result.Exception!.Message }
        };
    }
}