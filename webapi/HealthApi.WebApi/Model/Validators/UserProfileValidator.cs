using FluentValidation;
using HealthApi.Identity.Model;
using HealthApp.Domain;
using System;

namespace HealthApi.WebApi.Model.Validators
{
	public class UserProfileValidator: AbstractValidator<UserProfile>
	{
		public UserProfileValidator()
		{
			RuleFor(body => body.Email).NotEmpty();
			RuleFor(body => body.Email).EmailAddress();
			RuleFor(body => body.FirstName).NotEmpty();
			RuleFor(body => body.FirstName).MaximumLength(100);
			RuleFor(body => body.LastName).NotEmpty();
			RuleFor(body => body.LastName).MaximumLength(100);
			RuleFor(body => body.BirthDate).LessThanOrEqualTo(DateTime.Now);
			RuleFor(body => body.AvatarUrl).NotEmpty();
		}
	}
}
