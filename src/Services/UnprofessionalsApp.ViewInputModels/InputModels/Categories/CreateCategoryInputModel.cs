using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UnprofessionalsApp.ViewInputModels.InputModels.Categories
{
	public class CreateCategoryInputModel
	{
		[Required]
		[RegularExpression(@"^[a-zA-Z]+\ ?[a-zA-Z]*$", ErrorMessage = "Category name may contain only a single white space")]
		[StringLength(20, ErrorMessage = "Category name must be less than {0} characters")]
		[Display(Name = "Category Name: ")]
		public string Name { get; set; }
	}
}
