using HealthApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthApi.Persistence.EntityMappings
{
	public class MedicalRecordEntityMap: IEntityTypeConfiguration<MedicalRecordItem>
	{
        public void Configure(EntityTypeBuilder<MedicalRecordItem> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Details).HasGeneralTextField();
            builder.Property(c => c.Treatment).HasGeneralTextField();
        }
    }
}
