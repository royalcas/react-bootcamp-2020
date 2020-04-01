using HealthApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthApi.Persistence.EntityMappings
{
	public class PreventionActivityTopicEntityMap: IEntityTypeConfiguration<PreventionActivityTopic>
	{
        public void Configure(EntityTypeBuilder<PreventionActivityTopic> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).HasGeneralStringField();
            builder.Property(c => c.Benefits).HasGeneralStringField(GeneralFieldMapping.BigStringSize);
            builder.Property(c => c.Considerations).HasGeneralStringField(GeneralFieldMapping.BigStringSize);
        }
    }
}
