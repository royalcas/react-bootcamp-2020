using HealthApp.Domain;
using HealthApp.Domain.Contracts;

namespace HealthApi.Persistence.Repository
{
	public class MedicalRecordRepository: Repository<MedicalRecordItem>, IMedicalRecordRepository
	{
		public MedicalRecordRepository(HealthAppContext context)
			: base(context)
		{
		}
	}
}
