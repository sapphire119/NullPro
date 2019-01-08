namespace UnprofessionalsApp.Models
{
	using Microsoft.AspNetCore.Identity;
	using System;
	using System.Collections.Generic;


	// Add profile data for application users by adding properties to the UnprofessionalsAppUser class
	public class UnprofessionalsAppUser : IdentityUser<int>
	{
		public bool IsBlackListed { get; set; } = false;

		public string Description { get; set; }

		public int ImageId { get; set; }

		public virtual Image Image { get; set; }

		public DateTime DateOfRegistration { get; set; } = DateTime.UtcNow;

		public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();

		public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

		public virtual ICollection<Reply> Replies { get; set; } = new HashSet<Reply>();

		public virtual ICollection<Message> SentMessages { get; set; } = new HashSet<Message>();

		public virtual ICollection<Message> RecievedMessages { get; set; } = new HashSet<Message>();

		public virtual ICollection<Report> CreatedReports { get; set; } = new HashSet<Report>();

		public virtual ICollection<Report> Reports { get; set; } = new HashSet<Report>();
	}
}
