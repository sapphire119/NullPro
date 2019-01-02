namespace UnprofessionalsApp.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using UnprofessionalsApp.Models;

	public class PostConfig : IEntityTypeConfiguration<Post>
	{
		public void Configure(EntityTypeBuilder<Post> builder)
		{
			builder.HasKey(e => e.Id);

			builder.Property(e => e.Title);

			builder.Property(e => e.Description);

			builder.Property(e => e.DateOfCreation);

			builder.Property(e => e.ImageUrl);

			builder.Property(e => e.Rating);

			builder.Property(e => e.Popularity);

			builder.HasOne(e => e.Firm)
				.WithMany(f => f.Posts)
				.HasForeignKey(e => e.FirmId);

			builder.HasOne(e => e.Category)
				.WithMany(c => c.Posts);

			builder.HasOne(e => e.User)
				.WithMany(u => u.Posts);
		}
	}
}
