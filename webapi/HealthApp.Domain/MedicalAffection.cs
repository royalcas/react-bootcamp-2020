namespace HealthApp.Domain
{
	public class MedicalAffection: Entity
	{
		public MedicalAffectionType Type { get; set; }
		public string Name { get; set; }
		public string Symptoms { get; set; }
		public string Treatment { get; set; }
	}
}
