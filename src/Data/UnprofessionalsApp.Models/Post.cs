using System;
using System.Collections.Generic;
using UnprofessionalsApp.Common;

namespace UnprofessionalsApp.Models
{
	public class Post : BaseModel<int>
	{
		public Post() { }

		public Post(string title, string description)
			: this()
		{
			this.Title = title;
			this.Description = description;
		}

		public string Title { get; set; }

		public string Description { get; set; }

		public string ImageUrl { get; set; }

		public DateTime DateOfCreation { get; set; } = DateTime.UtcNow;

		public int UserId { get; set; }

		public virtual UnprofessionalsAppUser User { get; set; }

		public int CategoryId { get; set; }

		public virtual Category Category { get; set; }

		public Guid? FirmId { get; set; }

		public virtual Firm Firm { get; set; }

		public virtual ICollection<TagPost> Tags { get; set; } = new HashSet<TagPost>();

		public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

		public virtual ICollection<Report> Reports { get; set; } = new HashSet<Report>();
	}
}
