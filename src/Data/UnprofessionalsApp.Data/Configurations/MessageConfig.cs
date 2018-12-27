namespace UnprofessionalsApp.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using UnprofessionalsApp.Models;

	public class MessageConfig : IEntityTypeConfiguration<Message>
	{
		public void Configure(EntityTypeBuilder<Message> builder)
		{
			builder.HasKey(e => e.Id);

			builder.Property(e => e.Description);

			builder.Property(e => e.DateOfCreation);

			builder.HasOne(e => e.Sender)
				.WithMany(u => u.SentMessages)
				.HasForeignKey(e => e.SenderId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(e => e.Reciever)
				.WithMany(u => u.RecievedMessages)
				.HasForeignKey(e => e.ReceiverId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
