using HealthApp.Domain;
using HealthApp.Domain.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace HealthApi.Persistence.Repository
{
	public class MedicalRecordRepository: Repository<MedicalRecordItem>, IMedicalRecordRepository
	{
		public MedicalRecordRepository(HealthAppContext context)
			: base(context)
		{
		}

		public IEnumerable<MedicalRecordItem> GetMedicalRecordByUser(string userId)
		{
			return GetAll().Where(item => item.UserId == userId).OrderByDescending(item => item.Date);
		}
	}
}
