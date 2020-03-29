using FluentValidation;
using HealthApi.Identity.Model;
using HealthApp.Domain;
using System;

namespace HealthApi.WebApi.Model.Validators
{
	public class AccountRegisterValidator : AbstractValidator<AccountRegisterDto>
	{
		public AccountRegisterValidator()
		{
			RuleFor(body => body.FirstName).NotEmpty();
			RuleFor(body => body.FirstName).MaximumLength(100);
			RuleFor(body => body.LastName).NotEmpty();
			RuleFor(body => body.LastName).MaximumLength(100);
			RuleFor(body => body.Email).NotEmpty();
			RuleFor(body => body.Email).EmailAddress();
			RuleFor(body => body.Password).NotEmpty();
			RuleFor(body => body.Password).MinimumLength(6);
			RuleFor(body => body.Password).MaximumLength(100);

			RuleFor(body => body.Gender).IsInEnum();

			RuleFor(body => body.AvatarUrl).NotEmpty();
			RuleFor(body => body.AvatarUrl).Must( url => {
				return Uri.TryCreate(url, UriKind.Absolute, out Uri tempUrl);
			}).WithMessage("{PropertyName} is not a valid Url Format");
		}
	}
}
