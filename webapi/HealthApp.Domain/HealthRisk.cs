using System.Collections.Generic;

namespace HealthApp.Domain
{
	public class HealthRisk: Entity
	{
		public string Name { get; set; }
		public IEnumerable<ActivitySuggestionByRisk> ActivityTopicSuggestions { get; set; }
	}
}
