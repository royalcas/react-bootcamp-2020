using HealthApp.Domain;
using System.Collections.Generic;

namespace HealthApi.Application.Services
{
	public interface IMedicalRecordService : IApplicationRepositoryService<MedicalRecordItem>
	{
		IEnumerable<MedicalRecordItem> GetMedicalRecordByUser(string userId);
	}
}
