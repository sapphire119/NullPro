namespace UnprofessionalsApp.ViewInputModels.ViewModels.Posts
{
	using System;
	using System.Globalization;
	using System.Net;
	//using AutoMapper;
	using UnprofessionalsApp.Common;
	//using UnprofessionalsApp.Mapping.Contracts;
	//using UnprofessionalsApp.Models;

	public class PostViewModel /*: IMapFrom<Post>, IHaveCustomMappings*/
	{
		private string imageUrl;
		private string description;

		public int Id { get; set; }

		public string Title { get; set; }

		public string Description
		{
			get
			{
				//TODO: Test me
				var result = this.description.Length > GlobalConstants.AllowedCharactersToRenderForPostDescription ?
								string.Concat(
									this.description.Substring(0, GlobalConstants.AllowedCharactersToRenderForPostDescription),
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

		public int UserId { get; set; }

		public string Username { get; set; }

		public string ImageUrl { get; set; }

		//public void CreateMappings(IMapperConfigurationExpression configuration)
		//{
		//	configuration.CreateMap<Post, PostViewModel>()
		//		.ForMember(x => x.DateOfCreation, opts => opts.MapFrom(p => p.DateOfCreation.ToString(@"d MMMM, yyyy", CultureInfo.InvariantCulture)))
		//		.ForMember(x => x.Username, opts => opts.MapFrom(p => p.User.UserName));
		//}
	}
}
