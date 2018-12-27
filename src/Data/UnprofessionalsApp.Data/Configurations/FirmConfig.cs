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

			builder.Property(e => e.UniqueFirmId);

			builder.Property(e => e.Name);

			builder.Property(e => e.Popularity);

			builder.Property(e => e.Rating);

			builder.Property(e => e.UrlToTradersRegistry);

			builder.Property(e => e.IsBlackListed);

			builder.HasOne(e => e.User)
				.WithMany(u => u.Firms);

			builder.HasOne(e => e.Category)
				.WithMany(c => c.Firms);
		}
	}
}
