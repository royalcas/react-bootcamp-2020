using FluentValidation;
using HealthApi.Application.Models;

namespace HealthApi.Application.Validators
{
	public class MedicalRecordValidator: AbstractValidator<MedicalRecordItemModel>
	{
		public MedicalRecordValidator()
		{
			RuleFor(body => body.UserId).NotEmpty();
			RuleFor(body => body.Details).NotEmpty();
			RuleFor(body => body.Treatment).NotEmpty();
		}
	}
}
