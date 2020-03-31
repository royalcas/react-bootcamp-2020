using HealthApi.Application.Models;
using HealthApp.Domain;
using HealthApp.Domain.Contracts;
using System.Collections.Generic;

namespace HealthApi.Application.Services
{
	public class MedicalRecordService : ApplicationRepositoryService<IMedicalRecordRepository, MedicalRecordItemModel, MedicalRecordItem>, IMedicalRecordService
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
