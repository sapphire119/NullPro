using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UnprofessionalsApp.Common;

namespace UnprofessionalsApp.ViewInputModels.InputModels.Posts
{
	public class PostEntityDetailsInputModel
	{
		private string description;

		
		public int Id { get; set; }

		[Required]
		[DataType(DataType.Text)]
		public string Title { get; set; }

		[Required]
		[DataType(DataType.MultilineText)]
		public string Description
		{
			get
			{
				if (this.description.Length > GlobalConstants.AllowedCharactersToRenderForPostDetailsDescription)
				{
					var result = string.Concat(
						this.description.Substring(0, GlobalConstants.AllowedCharactersToRenderForPostDetailsDescription),
						GlobalConstants.DescriptionExtensionStrings);

					return result;
				}

				return this.description;
			}
			set
			{
				this.description = value;
			}
		}
	}
}
