using HealthApp.Domain;
using System;

namespace HealthApp.Domain
{
	public class Prescription: Entity
	{
		public float Quantity { get; set; }

		public Guid MedicationId { get; set; }
		public Medication Medication { get; set; }

		public Guid MedicalRecordItemId { get; set; }
		public MedicalRecordItem MedicalRecordItem { get; set; }
	}
}
