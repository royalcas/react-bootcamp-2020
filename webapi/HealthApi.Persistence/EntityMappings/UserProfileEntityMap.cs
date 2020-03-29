using HealthApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthApi.Persistence.EntityMappings
{
	public class UserProfileEntityMap: IEntityTypeConfiguration<UserProfile>
	{
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.Property(c => c.Id);

            builder.Property(c => c.FirstName).HasGeneralStringField();
            builder.Property(c => c.LastName).HasGeneralStringField();
            builder.Property(c => c.Email).HasGeneralStringField();
            builder.Property(c => c.AvatarUrl).HasGeneralStringField(GeneralFieldMapping.BigStringSize);

            // Relationships
            builder.HasMany(c => c.MedicalRecord)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired();
        }
    }
}
