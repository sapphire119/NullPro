using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UnprofessionalsApp.ViewInputModels.InputModels.Comments
{
	public class CommentEntityInputModel
	{
		public int Id { get; set; }

		[Required]
		[DataType(DataType.MultilineText)]
		public string Description { get; set; }
	}
}
