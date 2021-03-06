﻿using FluentValidation;
using HealthApi.Identity.Model;

namespace HealthApi.WebApi.Model.Validators
{
	public class LoginValidator : AbstractValidator<LoginDto>
	{
		public LoginValidator()
		{
			RuleFor(body => body.Email).NotEmpty();
			RuleFor(body => body.Email).EmailAddress();
			RuleFor(body => body.Password).NotEmpty();
			RuleFor(body => body.Password).MinimumLength(6);
			RuleFor(body => body.Password).MaximumLength(100);
		}
	}
}
