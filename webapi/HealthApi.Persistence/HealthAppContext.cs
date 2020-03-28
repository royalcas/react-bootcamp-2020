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

		public HealthAppContext(DbContextOptions<HealthAppContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new UserProfileEntityMap());
			modelBuilder.ApplyConfiguration(new MedicalRecordEntityMap());
			modelBuilder.ApplyConfiguration(new MedicineEntityMap());

			base.OnModelCreating(modelBuilder);
		}
	}
}
