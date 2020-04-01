using HealthApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;

namespace HealthApi.Persistence.EntityMappings
{
	public class HealthRiskEntityMap : IEntityTypeConfiguration<HealthRisk>
	{
		public void Configure(EntityTypeBuilder<HealthRisk> builder)
		{
			builder.HasKey(c => c.Id);
			builder.Property(c => c.Id).ValueGeneratedOnAdd();
			builder.Property(c => c.Name).HasGeneralStringField();

			// Data seed
			//builder.HasData(
			//	new HealthRisk()
			//	{
			//		Id = System.Guid.NewGuid().ToString(),
			//		Name = "Cardiovascular",
			//		ActivityTopicSuggestions = CreateSuggestionList(new List<string>() { "Regular exercise", "Keep optimal blood pressure" })
			//	},
			//	new HealthRisk()
			//	{
			//		Id = System.Guid.NewGuid().ToString(),
			//		Name = "Respiratory",
			//		ActivityTopicSuggestions = CreateSuggestionList(new List<string>() {
			//			"Spinning",
			//			"Walking",
			//			"Jogging",
			//			"Swimming",
			//		})
			//	},
			//	new HealthRisk()
			//	{
			//		Id = System.Guid.NewGuid().ToString(),
			//		Name = "Psychological",
			//		ActivityTopicSuggestions = CreateSuggestionList(new List<string>() {
			//			"Meditation",
			//			"Yoga",
			//			"Meetup",
			//			"Therapy",
			//		})

			//	},
			//	new HealthRisk()
			//	{
			//		Id = System.Guid.NewGuid().ToString(),
			//		Name = "Bone",
			//		ActivityTopicSuggestions = CreateSuggestionList(new List<string>() {
			//			"weight-bearing exercise",
			//			"avoid smoking",
			//		})
			//	},
			//	new HealthRisk()
			//	{
			//		Id = System.Guid.NewGuid().ToString(),
			//		Name = "Digestive",
			//		ActivityTopicSuggestions = CreateSuggestionList(new List<string>() {
			//			"Don't chew gum",
			//			"Eat and drink slowly",
			//			"Nutrition appointment",
			//		})
			//	},
			//	new HealthRisk()
			//	{
			//		Id = System.Guid.NewGuid().ToString(),
			//		Name = "Nervous",
			//		ActivityTopicSuggestions = CreateSuggestionList(new List<string>() {
			//			"Get plenty of rest",
			//			"Do not use alcohol or illegal drugs",
			//			"Set priorities, and concentrate on one thing at a time",
			//		})
			//	},
			//	new HealthRisk()
			//	{
			//		Id = System.Guid.NewGuid().ToString(),
			//		Name = "Renal",
			//		ActivityTopicSuggestions = CreateSuggestionList(new List<string>() {
			//			"Drink a lot of water",
			//			"Go frequently to the bathroom",
			//		})
			//	}
			//) ;
		}

		//private ActivitySuggestionByRisk CreateSuggestion(string name)
		//{
		//	return new ActivitySuggestionByRisk()
		//	{
		//		Id = System.Guid.NewGuid().ToString(),
		//		ActivityTopic = new PreventionActivityTopic()
		//		{
		//			Id = System.Guid.NewGuid().ToString(),
		//			Name = name
		//		}
		//	};
		//}

		//private List<ActivitySuggestionByRisk> CreateSuggestionList(List<string> suggestions)
		//{
		//	return suggestions.Select(item => CreateSuggestion(item)).ToList();
		//}
	}
}
