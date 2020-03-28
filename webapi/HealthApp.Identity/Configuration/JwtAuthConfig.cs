namespace HealthApi.Identity.Configuration
{
	public class JwtAuthConfig
	{
		public string Key { get; set; }
		public string Issuer { get; set; }
		public int ExpireDays { get; set; }
	}
}
