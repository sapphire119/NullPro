using System;
using System.Collections.Generic;
using System.Text;
using UnprofessionalsApp.Common;

namespace UnprofessionalsApp.ViewInputModels.ViewModels.Comments
{
	public class CommentUserProfileViewModel
	{
		private string description;

		public int Id { get; set; }

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

		public string DateOfCreation { get; set; }

		public int UserId { get; set; }

		public int PostId { get; set; }

		public string PostTitle { get; set; }
	}
}
