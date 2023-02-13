using DripChip.Core.Extensions;
using System.ComponentModel.DataAnnotations;

namespace DripChip.Web.Extensions;

public static class ValidationResult
{
    public static Result ToResult(this FluentValidation.Results.ValidationResult validationResult)
    {
        return validationResult.IsValid
            ? Result.Success()
            : Result.Fail(new ValidationException(validationResult.ToString()));
    }
}