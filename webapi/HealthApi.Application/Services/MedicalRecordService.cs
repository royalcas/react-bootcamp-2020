using HealthApp.Domain;
using HealthApp.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthApi.Application.Services
{
	public class MedicalRecordService : ApplicationRepositoryService<MedicalRecordItem>, IMedicalRecordService
	{
		public MedicalRecordService(IMedicalRecordRepository repository, IUnitOfWork unitOfWork)
			: base(repository, unitOfWork)
		{
		}
	}
}
