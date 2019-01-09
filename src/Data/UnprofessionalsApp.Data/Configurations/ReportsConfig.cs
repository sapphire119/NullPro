namespace UnprofessionalsApp.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using UnprofessionalsApp.Models;

	public class ReportsConfig : IEntityTypeConfiguration<Report>
	{
		public void Configure(EntityTypeBuilder<Report> builder)
		{
			builder.HasKey(e => e.Id);

			builder.Property(e => e.Description)
				.IsRequired();

			builder.Property(e => e.IsDeleted);

			builder.Property(e => e.CreationDate);

			builder.HasOne(e => e.User)
				.WithMany(u => u.CreatedReports)
				.HasForeignKey(e => e.UserId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(e => e.Comment)
				.WithMany(c => c.Reports)
				.HasForeignKey(e => e.CommentId);

			builder.HasOne(e => e.Firm)
				.WithMany(f => f.Reports)
				.HasForeignKey(e => e.FirmId);

			builder.HasOne(e => e.Post)
				.WithMany(p => p.Reports)
				.HasForeignKey(e => e.PostId);

			builder.HasOne(e => e.Reply)
				.WithMany(r => r.Reports)
				.HasForeignKey(e => e.ReplyId);

			builder.HasOne(e => e.ReportedUser)
				.WithMany(e => e.Reports)
				.HasForeignKey(e => e.ReportedUserId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
