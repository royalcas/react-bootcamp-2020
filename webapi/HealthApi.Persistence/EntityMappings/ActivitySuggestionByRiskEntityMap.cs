using HealthApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthApi.Persistence.EntityMappings
{
	public class ActivitySuggestionByRiskEntityMap : IEntityTypeConfiguration<ActivitySuggestionByRisk>
	{
		public void Configure(EntityTypeBuilder<ActivitySuggestionByRisk> builder)
		{
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            // Relationships
            builder.HasOne(c => c.ActivityTopic)
                .WithMany(e => e.RiskBasedSuggestions)
                .HasForeignKey(e => e.ActivityTopicId)
                .IsRequired();

            builder.HasOne(c => c.Risk)
                .WithMany(e => e.ActivityTopicSuggestions)
                .HasForeignKey(e => e.RiskId)
                .IsRequired();
        }
	}
}
