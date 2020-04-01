namespace HealthApp.Domain
{
	public class UserIdentifiedRisk: Entity
	{
		public string RiskId { get; set; }

		public HealthRisk Risk { get; set; }

		public string UserId { get; set; }

		public UserProfile User { get; set; }
	}
}
