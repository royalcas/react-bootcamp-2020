using HealthApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthApi.Persistence.EntityMappings
{
	public class MedicineEntityMap: IEntityTypeConfiguration<Medication>
	{
        public void Configure(EntityTypeBuilder<Medication> builder)
        {
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).HasGeneralStringField();
        }
    }
}
