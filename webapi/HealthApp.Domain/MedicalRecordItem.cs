using System;
using System.Collections.Generic;

namespace HealthApp.Domain
{
	public class MedicalRecordItem: Entity
	{
		public DateTime Date { get; set; }
		public string Details { get; set; }
		public string Treatment { get; set; }

		public Guid UserId { get; set; }
		public UserProfile User { get; set; }

		public IEnumerable<Medication> Medicine { get; set; }
	}
}
