namespace HealthApi.Identity.Model
{
	public class IdentityResponse
	{
		public bool Success { get; set; }
		public string AuthorizationToken { get; set; }

		public string UserId { get; set; }
	}
}

