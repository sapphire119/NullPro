using System.ComponentModel.DataAnnotations;

namespace UnprofessionalsApp.ViewInputModels.InputModels.Comments
{
	public class CreateInputModel
	{
		[RegularExpression(@"^\d+$")]
		public int PostId { get; set; }
		
		[RegularExpression(@"^\d+$")]
		public int UserId { get; set; }

		[Required]
		[DataType(DataType.MultilineText)]
		public string Description { get; set; }
	}
}
