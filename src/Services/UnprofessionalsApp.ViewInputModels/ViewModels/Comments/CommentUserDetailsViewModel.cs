using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
//using AutoMapper;
using UnprofessionalsApp.Common;
//using UnprofessionalsApp.Mapping.Contracts;
//using UnprofessionalsApp.Models;

namespace UnprofessionalsApp.ViewInputModels.ViewModels.Comments
{
	public class CommentUserDetailsViewModel /*: IMapFrom<Comment>, IHaveCustomMappings*/
	{
		private string description;

		public int Id { get; set; }

		public string Description
		{
			get
			{
				var result = this.description.Length > GlobalConstants.AllowedCharactersToRenderForPostDetailsDescription ?
								string.Concat(
									this.description.Substring(0, GlobalConstants.AllowedCharactersToRenderForPostDetailsDescription),
									GlobalConstants.DescriptionExtensionStrings)
										: this.description;
				return result;
			}
			set
			{
				this.description = value;
			}
		}

		public string DateOfCreation { get; set; }
		
		//Potential break
		public int PostId { get; set; }

		public string PostTitle { get; set; }

		//public void CreateMappings(IMapperConfigurationExpression configuration)
		//{
		//	configuration.CreateMap<Comment, CommentUserDetailsViewModel>()
		//		.ForMember(x => x.DateOfCreation, opts => opts.MapFrom(c => c.DateOfCreation.ToString(@"d MMMM yyyy", CultureInfo.InvariantCulture)))
		//		.ForMember(x => x.PostTitle, opts => opts.MapFrom(c => c.Post.Title));
		//}
	}
}
