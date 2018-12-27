using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace UnprofessionalsApp.Models
{
	// Add profile data for application users by adding properties to the UnprofessionalsAppUser class
	public class UnprofessionalsAppUser : IdentityUser<int>
	{
		public bool IsBlackListed { get; set; } = false;

		public DateTime DateOfRegistration { get; set; } = DateTime.UtcNow;

		public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();

		public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

		public virtual ICollection<Reply> Replies { get; set; } = new HashSet<Reply>();

		public virtual ICollection<Message> SentMessages { get; set; } = new HashSet<Message>();

		public virtual ICollection<Message> RecievedMessages { get; set; } = new HashSet<Message>();

		public virtual ICollection<Firm> Firms { get; set; } = new HashSet<Firm>();
	}
}
