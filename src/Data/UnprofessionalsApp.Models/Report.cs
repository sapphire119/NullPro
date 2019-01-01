namespace UnprofessionalsApp.Models
{
	using System;
	using UnprofessionalsApp.Common;

	public class Report : BaseModel<int>
	{
		public string Description { get; set; }

		public DateTime CreationDate { get; set; } = DateTime.UtcNow;

		public int? CommentId { get; set; }

		public virtual Comment Comment { get; set; }

		public int? PostId { get; set; }

		public virtual Post Post { get; set; }

		public int? ReplyId { get; set; }

		public virtual Reply Reply { get; set; }

		public Guid? FirmId { get; set; }

		public virtual Firm Firm { get; set; }

		public int? ReportedUserId { get; set; }

		public virtual UnprofessionalsAppUser ReportedUser { get; set; }

		public int UserId { get; set; }

		public virtual UnprofessionalsAppUser User { get; set; }

	}
}
