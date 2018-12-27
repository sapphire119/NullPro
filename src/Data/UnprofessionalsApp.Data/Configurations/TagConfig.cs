namespace UnprofessionalsApp.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using UnprofessionalsApp.Models;

	public class TagConfig : IEntityTypeConfiguration<Tag>
	{
		public void Configure(EntityTypeBuilder<Tag> builder)
		{
			builder.HasKey(e => e.Id);

			builder.Property(e => e.Name);
		}
	}
}
