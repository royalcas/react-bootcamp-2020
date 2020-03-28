namespace HealthApp.Domain
{
	public class Medication: Entity
	{
		public MedicationType Type { get; set; }
		public string Name { get; set; }
	}
}
