using HealthApi.Application.Models;
using HealthApp.Domain;
using System.Collections.Generic;

namespace HealthApi.Application.Services
{
	public interface IMedicalRecordService : IApplicationRepositoryService<MedicalRecordItemModel>
	{
		IEnumerable<MedicalRecordItem> GetMedicalRecordByUser(string userId);
	}
}
