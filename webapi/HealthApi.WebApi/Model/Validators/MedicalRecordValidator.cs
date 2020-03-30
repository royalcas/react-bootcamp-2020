using FluentValidation;
using HealthApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthApi.WebApi.Model.Validators
{
	public class MedicalRecordValidator: AbstractValidator<MedicalRecordItem>
	{
		public MedicalRecordValidator()
		{
			RuleFor(body => body.UserId).NotEmpty();
			RuleFor(body => body.Details).NotEmpty();
			RuleFor(body => body.Treatment).NotEmpty();
		}
	}
}
