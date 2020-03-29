using System.Collections.Generic;

namespace HealthApp.Domain
{
	public class Medication: Entity
	{
		public MedicationType Type { get; set; }
		public string Name { get; set; }

		public IEnumerable<Prescription> Prescriptions { get; set; }
	}
}
