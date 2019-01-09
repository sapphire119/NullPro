using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnprofessionalsApp.Common;

namespace UnprofessionalsApp.ViewInputModels.ViewModels.Users
{
	public class UserViewModel
	{
		private string description;

		public int Id { get; set; }

		public string Username { get; set; }

		public string Description
		{
			get
			{
				this.description = this.description ?? GlobalConstants.UserHasNoDescriptionMessage;

				var result = this.description != null && this.description.Count() > GlobalConstants.DefaultUserDescriptionRenderCount ?
					string.Concat(
						this.description.Substring(0, GlobalConstants.DefaultUserDescriptionRenderCount),
						GlobalConstants.DescriptionExtensionStrings) 
						: this.description;

				return result;
			}
			set
			{
				this.description = value;
			}
		}

		public string ImageUrl { get; set; }
	}
}
