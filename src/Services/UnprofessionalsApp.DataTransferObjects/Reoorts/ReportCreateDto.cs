using System;
using System.Collections.Generic;
using System.Text;

namespace UnprofessionalsApp.DataTransferObjects.Reoorts
{
	public class ReportCreateDto
	{
		public string Description { get; set; }

		public int? CommentId { get; set; }

		public int? PostId { get; set; }

		public int? ReplyId { get; set; }

		public Guid? FirmId { get; set; }

		public int? ReportedUserId { get; set; }

		public int UserId { get; set; }
	}
}
