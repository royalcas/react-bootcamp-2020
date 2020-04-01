using HealthApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthApi.Persistence.EntityMappings
{
	public class UserActivitySubscriptionEntityMap: IEntityTypeConfiguration<UserActivitySubscription>
    {
        public void Configure(EntityTypeBuilder<UserActivitySubscription> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            // Relationships
            builder.HasOne(c => c.User)
                .WithMany(e => e.ActivityTopicSubscriptions)
                .HasForeignKey(e => e.UserId)
                .IsRequired();

            builder.HasOne(c => c.ActivityTopic)
                .WithMany(e => e.UserSubscriptions)
                .HasForeignKey(e => e.ActivityTopicId)
                .IsRequired();
        }
    }
}
