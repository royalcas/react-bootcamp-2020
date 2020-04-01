using System;
using System.Collections.Generic;
using System.Text;

namespace HealthApp.Domain
{
	public class ActivitySuggestionByRisk: Entity
	{
		public string RiskId { get; set; }
		public HealthRisk Risk { get; set; }
		public string ActivityTopicId { get; set; }
		public PreventionActivityTopic ActivityTopic { get; set; }
	}
}
