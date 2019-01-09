using System;
using System.Collections.Generic;
using UnprofessionalsApp.Common;

namespace UnprofessionalsApp.Models
{
	public class Comment : BaseModel<int>
	{
		public string Description { get; set; }

		public DateTime DateOfCreation { get; set; } = DateTime.UtcNow;

		public bool IsDeleted { get; set; } = false;

		public int UserId { get; set; }

		public virtual UnprofessionalsAppUser User { get; set; }

		public int PostId { get; set; }

		public virtual Post Post { get; set; }

		public virtual ICollection<Reply> Replies { get; set; } = new HashSet<Reply>();

		public virtual ICollection<Report> Reports { get; set; } = new HashSet<Report>();
	}
}
