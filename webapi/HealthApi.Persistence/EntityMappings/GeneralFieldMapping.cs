using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthApi.Persistence.EntityMappings
{
	public static class GeneralFieldMapping
	{
		public const int DefaultStringSize = 256;
		public const int BigStringSize = 512;
		public const int SmallStringSize = 128;

		public static void HasGeneralStringField<TProperty>(this PropertyBuilder<TProperty> propBuilder, int size = DefaultStringSize, bool isRequired = true)
		{
			propBuilder.HasMaxLength(256).IsRequired(isRequired);
		}

		public static void HasGeneralTextField<TProperty>(this PropertyBuilder<TProperty> propBuilder, bool isRequired = true)
		{
			propBuilder.IsRequired(isRequired);
		}
	}
}
