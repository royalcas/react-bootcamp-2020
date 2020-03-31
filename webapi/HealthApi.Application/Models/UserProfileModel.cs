using HealthApp.Domain;
using System;

namespace HealthApi.Application.Models
{
	public class UserProfileModel: Model
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string AvatarUrl { get; set; }
		public DateTime BirthDate { get; set; }
		public Gender Gender { get; set; }
	}
}
