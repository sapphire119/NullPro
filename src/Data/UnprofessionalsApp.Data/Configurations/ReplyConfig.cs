namespace UnprofessionalsApp.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using UnprofessionalsApp.Models;

	public class ReplyConfig : IEntityTypeConfiguration<Reply>
	{
		public void Configure(EntityTypeBuilder<Reply> builder)
		{
			builder.HasKey(e => e.Id);

			builder.Property(e => e.Description);

			builder.Property(e => e.IsDeleted);

			builder.Property(e => e.DateOfCreation);

			builder.HasOne(e => e.Comment)
				.WithMany(c => c.Replies);

			builder.HasOne(e => e.User)
				.WithMany(u => u.Replies);
		}
	}
}
