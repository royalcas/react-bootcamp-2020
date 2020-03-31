using FluentValidation;
using HealthApi.Application.Validators;

namespace HealthApi.WebApi.Model.Validators
{
	public class AccountRegisterValidator : UserProfileValidator<AccountRegisterDto>
	{
		public AccountRegisterValidator()
		{
			RuleFor(body => body.Password).NotEmpty();
			RuleFor(body => body.Password).MinimumLength(6);
			RuleFor(body => body.Password).MaximumLength(100);
		}
	}
}
