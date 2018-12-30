using System;
using UnprofessionalsApp.Common;

namespace UnprofessionalsApp.Models
{
	public class Reply : BaseModel<int>
	{
		public string Description { get; set; }

		public int Rating { get; set; } = 0;

		public DateTime DateOfCreation { get; set; } = DateTime.UtcNow;

		public int CommentId { get; set; }

		public virtual Comment Comment { get; set; }

		public int UserId { get; set; }

		public virtual UnprofessionalsAppUser User { get; set; }
	}
}
