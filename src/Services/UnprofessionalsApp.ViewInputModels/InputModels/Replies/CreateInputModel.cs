using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UnprofessionalsApp.ViewInputModels.InputModels.Replies
{
	public class CreateInputModel
	{
		[RegularExpression(@"^\d+$")]
		public int CommentId { get; set; }

		[RegularExpression(@"^\d+$")]
		public int UserId { get; set; }


		[RegularExpression(@"^\d+$")]
		public int PostId { get; set; }

		[Required]
		[DataType(DataType.MultilineText)]
		public string Description { get; set; }
	}
}
