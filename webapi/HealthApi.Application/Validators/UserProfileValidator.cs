using FluentValidation;
using HealthApi.Application.Models;
using System;

namespace HealthApi.Application.Validators
{
	public class UserProfileValidator<TUserProfile>: AbstractValidator<TUserProfile> where TUserProfile: UserProfileModel
	{
		public UserProfileValidator()
		{
			RuleFor(body => body.FirstName).NotEmpty();
			RuleFor(body => body.FirstName).MaximumLength(100);
			RuleFor(body => body.LastName).NotEmpty();
			RuleFor(body => body.LastName).MaximumLength(100);
			RuleFor(body => body.Email).NotEmpty();
			RuleFor(body => body.Email).EmailAddress();
			RuleFor(body => body.BirthDate).LessThanOrEqualTo(DateTime.Now);
			RuleFor(body => body.Gender).IsInEnum();

			RuleFor(body => body.AvatarUrl).NotEmpty();
			RuleFor(body => body.AvatarUrl).Must(url => {
				return Uri.TryCreate(url, UriKind.Absolute, out Uri tempUrl);
			}).WithMessage("{PropertyName} is not a valid Url Format");
		}
	}

	public class BasicUserProfileValidator : UserProfileValidator<UserProfileModel> 
	{
	}
}
