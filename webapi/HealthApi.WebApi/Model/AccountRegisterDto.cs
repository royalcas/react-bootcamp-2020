using HealthApp.Domain;

namespace HealthApi.WebApi.Model
{
	public class AccountRegisterDto: UserProfile
	{
		public string Password { get; set; }
	}
}
