namespace UnprofessionalsApp.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using UnprofessionalsApp.Models;

	public class FirmConfig : IEntityTypeConfiguration<Firm>
	{
		public void Configure(EntityTypeBuilder<Firm> builder)
		{
			builder.HasKey(e => e.Id);

			builder.Property(e => e.IsDeleted);

			builder.Property(e => e.UniqueFirmId)
				.HasMaxLength(9)
				.IsRequired();

			builder.Property(e => e.Name)
				.IsRequired();
			
			builder.Property(e => e.LegalForm)
				.IsRequired();
		}
	}
}
