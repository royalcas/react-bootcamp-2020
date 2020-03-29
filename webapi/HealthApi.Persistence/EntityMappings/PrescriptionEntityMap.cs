using HealthApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthApi.Persistence.EntityMappings
{
	public class PrescriptionEntityMap: IEntityTypeConfiguration<Prescription>
	{
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            // Relationships
            builder.HasOne(c => c.Medication)
                .WithMany(e => e.Prescriptions)
                .HasForeignKey(e => e.MedicationId)
                .IsRequired();

            builder.HasOne(c => c.MedicalRecordItem)
                .WithMany(e => e.Prescriptions)
                .HasForeignKey(e => e.MedicalRecordItemId)
                .IsRequired();
        }
    }
}
