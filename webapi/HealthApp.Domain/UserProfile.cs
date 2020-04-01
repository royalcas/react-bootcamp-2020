using System;
using System.Collections.Generic;

namespace HealthApp.Domain
{
	public class UserProfile: Entity
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string AvatarUrl { get; set; }
		public DateTime BirthDate { get; set; }
		public Gender Gender { get; set; }

		public IEnumerable<MedicalRecordItem> MedicalRecord { get; set; }

		public IEnumerable<UserActivitySubscription> ActivityTopicSubscriptions { get; set; }
	}
}
