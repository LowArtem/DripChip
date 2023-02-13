using DripChip.Application.Dto;
using FluentValidation;
using FluentValidation.Validators;

namespace DripChip.Web.Validation.User;

public class AccountManagementValidation : AbstractValidator<UserRequestDto.AccountManagement>
{
    public AccountManagementValidation()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
    }
}