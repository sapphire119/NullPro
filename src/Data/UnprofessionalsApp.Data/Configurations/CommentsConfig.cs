namespace UnprofessionalsApp.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using UnprofessionalsApp.Models;

	public class CommentsConfig : IEntityTypeConfiguration<Comment>
	{
		public void Configure(EntityTypeBuilder<Comment> builder)
		{
			builder.HasKey(e => e.Id);

			builder.Property(e => e.Description);

			builder.Property(e => e.DateOfCreation);

			builder.HasOne(e => e.User)
				.WithMany(u => u.Comments)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(e => e.Post)
				.WithMany(p => p.Comments)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
