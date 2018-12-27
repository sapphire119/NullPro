namespace UnprofessionalsApp.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using UnprofessionalsApp.Models;

	public class TagPostConfig : IEntityTypeConfiguration<TagPost>
	{
		public void Configure(EntityTypeBuilder<TagPost> builder)
		{
			builder.HasKey(e => new { e.TagId, e.PostId });

			builder.HasOne(e => e.Tag)
				.WithMany(t => t.Posts);

			builder.HasOne(e => e.Post)
				.WithMany(p => p.Tags);
		}
	}
}
