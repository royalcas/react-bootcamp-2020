using System;
using System.Collections.Generic;
using System.Text;

namespace HealthApp.Domain
{
	public class PreventionActivityTopic: Entity
	{
		public string Name { get; set; }
		public string Benefits { get; set; }
		public string Considerations { get; set; }

		public IEnumerable<UserActivitySubscription> UserSubscriptions { get; set; }
		public IEnumerable<ActivitySuggestionByRisk> RiskBasedSuggestions { get; set; }
	}
}
