using System;
using System.Collections.Generic;
using System.Text;

namespace UnprofessionalsApp.ViewInputModels.ViewModels.Reports
{
	public class ReportViewModel
	{
		public int Id { get; set; }

		public string Description { get; set; }

		public string CreationDate { get; set; }

		public int? CommentId { get; set; }

		public int? PostId { get; set; }

		public int? ReplyId { get; set; }

		public string FirmId { get; set; }

		public int? ReportedUserId { get; set; }

		public int UserId { get; set; }

		public string Username { get; set; }
	}
}
