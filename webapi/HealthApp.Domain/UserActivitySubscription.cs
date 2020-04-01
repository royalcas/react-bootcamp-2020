using System;
using System.Collections.Generic;
using System.Text;

namespace HealthApp.Domain
{
	public class UserActivitySubscription: Entity
	{
		public string UserId { get; set; }

		public UserProfile User { get; set; }

		public string ActivityTopicId { get; set; }

		public PreventionActivityTopic ActivityTopic { get; set; }

	}
}
