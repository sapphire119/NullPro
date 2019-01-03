namespace UnprofessionalsApp.ViewInputModels.ViewModels.Posts
{
	using System;
	using System.Globalization;
	using System.Net;
	using AutoMapper;
	using UnprofessionalsApp.Mapping.Contracts;
	using UnprofessionalsApp.Models;
	using UnprofessionalsApp.ViewInputModels.Extension;

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
				var result = this.description.Length > ProjectConsants.AllowedCharactersToRender ?
								string.Concat(
									this.description.Substring(0, ProjectConsants.AllowedCharactersToRender),
									ProjectConsants.DescriptionExtensionStrings)
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
					ProjectConsants.DefaultImageUrl : this.imageUrl;

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
