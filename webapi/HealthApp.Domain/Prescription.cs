using HealthApp.Domain;
using System;

namespace HealthApp.Domain
{
	public class Prescription: Entity
	{
		public float Quantity { get; set; }

		public string MedicationId { get; set; }
		public Medication Medication { get; set; }

		public string MedicalRecordItemId { get; set; }
		public MedicalRecordItem MedicalRecordItem { get; set; }
	}
}
