using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using AutoMapper;
using UnprofessionalsApp.Mapping.Contracts;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.Extension;

namespace UnprofessionalsApp.ViewInputModels.ViewModels.Categories
{
	public class PostByCategoryViewModel : IMapFrom<Post>, IHaveCustomMappings
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

		public DateTime DateOfCreation { get; set; }

		public int UserId { get; set; }

		public string Username { get; set; }

		public void CreateMappings(IMapperConfigurationExpression configuration)
		{
			configuration.CreateMap<Post, PostByCategoryViewModel>()
					.ForMember(x => x.Username, opts => opts.MapFrom(p => p.User.UserName));
		}
	}
}
