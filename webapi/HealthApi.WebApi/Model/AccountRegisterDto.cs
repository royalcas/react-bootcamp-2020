using HealthApi.Application.Models;
using HealthApp.Domain;

namespace HealthApi.WebApi.Model
{
	public class AccountRegisterDto: UserProfileModel
	{
		public string Password { get; set; }
	}
}
