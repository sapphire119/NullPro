using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UnprofessionalsApp.ViewInputModels.InputModels.Reports
{
	public class ReporCreateInputModel
	{
		[Required]
		[DataType(DataType.MultilineText)]
		public string Description { get; set; }
		
		public int? CommentId { get; set; }

		public int? PostId { get; set; }

		public int? ReplyId { get; set; }

		public string FirmId { get; set; }

		public int? ReportedUserId { get; set; }
	}
}
