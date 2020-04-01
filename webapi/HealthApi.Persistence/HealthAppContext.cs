using HealthApi.Persistence.EntityMappings;
using HealthApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HealthApi.Persistence
{
	public class HealthAppContext: DbContext
	{
		public DbSet<UserProfile> Users { get; set; }
		public DbSet<MedicalRecordItem> MedicalRecords { get; set; }
		public DbSet<Medication> Medications { get; set; }
		public DbSet<Prescription> Prescriptions { get; set; }
		public DbSet<HealthRisk> HealthRisks { get; set; }
		public DbSet<PreventionActivityTopic> PreventionActivityTopics { get; set; }
		public DbSet<UserActivitySubscription> UserActivitySubscriptions { get; set; }
		public DbSet<UserIdentifiedRisk> UserIdentifiedRisks { get; set; }
		public DbSet<ActivitySuggestionByRisk> ActivitySuggestionsByRisk { get; set; }
		public DbSet<PreventionTip> Tips { get; set; }

		public HealthAppContext(DbContextOptions<HealthAppContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new UserProfileEntityMap());
			modelBuilder.ApplyConfiguration(new MedicalRecordEntityMap());
			modelBuilder.ApplyConfiguration(new MedicineEntityMap());
			modelBuilder.ApplyConfiguration(new PrescriptionEntityMap());
			modelBuilder.ApplyConfiguration(new ActivitySuggestionByRiskEntityMap());
			modelBuilder.ApplyConfiguration(new UserActivitySubscriptionEntityMap());
			modelBuilder.ApplyConfiguration(new HealthRiskEntityMap());
			modelBuilder.ApplyConfiguration(new PreventionActivityTopicEntityMap());


			base.OnModelCreating(modelBuilder);
		}
	}
}
