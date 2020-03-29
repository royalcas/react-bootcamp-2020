using HealthApp.Domain;
using HealthApp.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthApi.Application.Services
{
	public class MedicalRecordService : ApplicationRepositoryService<IMedicalRecordRepository, MedicalRecordItem>, IMedicalRecordService
	{
		public MedicalRecordService(IMedicalRecordRepository repository, IUnitOfWork unitOfWork)
			: base(repository, unitOfWork)
		{
		}

		public IEnumerable<MedicalRecordItem> GetMedicalRecordByUser(string userId)
		{
			return _repository.GetMedicalRecordByUser(userId);
		}
	}
}
