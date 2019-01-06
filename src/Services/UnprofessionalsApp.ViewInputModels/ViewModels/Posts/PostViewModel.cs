namespace UnprofessionalsApp.ViewInputModels.ViewModels.Posts
{
	using System;
	using System.Net;
	using AutoMapper;
	using UnprofessionalsApp.Common;
	using UnprofessionalsApp.Mapping.Contracts;
	using UnprofessionalsApp.Models;

	public class PostViewModel : IMapFrom<Post>, IHaveCustomMappings
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

		public DateTime DateOfCreation { get; set; }

		public int UserId { get; set; }

		public string Username { get; set; }

		public string ImageUrl
		{
			get
			{
				//TODO: Test me
				var result = string.IsNullOrWhiteSpace(this.imageUrl) ?
					GlobalConstants.DefaultImageUrl : this.imageUrl;

				result = WebUtility.UrlDecode(result);

				return result;
			}
			set
			{
				this.imageUrl = value;
			}
		}

		public void CreateMappings(IMapperConfigurationExpression configuration)
		{
			configuration.CreateMap<Post, PostViewModel>()
				.ForMember(x => x.Username, opts => opts.MapFrom(p => p.User.UserName));
		}
	}
}
