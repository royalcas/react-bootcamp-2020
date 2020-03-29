using System.Collections.Generic;

namespace HealthApp.Domain.Contracts
{
	public interface IMedicalRecordRepository: IRepository<MedicalRecordItem>
	{
		IEnumerable<MedicalRecordItem> GetMedicalRecordByUser(string userId);
	}
}
