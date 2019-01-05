using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using UnprofessionalsApp.Mapping.Contracts;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.Extension;
using System.Net;
using UnprofessionalsApp.ViewInputModels.ViewModels.Tags;
using UnprofessionalsApp.ViewInputModels.ViewModels.Comments;

namespace UnprofessionalsApp.ViewInputModels.ViewModels.Posts
{
	public class PostDetailsViewModel : IMapFrom<Post>, IHaveCustomMappings
	{
		private string imageUrl;

		public int Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public string ImageUrl
		{
			get
			{
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

		public int CategoryId { get; set; }

		public Guid? FirmId { get; set; }

		public string FirmName { get; set; }

		public IEnumerable<CommentViewModel> Comments { get; set; }

		public IEnumerable<TagViewModel> Tags { get; set; }

		public void CreateMappings(IMapperConfigurationExpression configuration)
		{
			configuration.CreateMap<Post, PostDetailsViewModel>()
				.ForMember(x => x.Username, opts => opts.MapFrom(p => p.User.UserName))
				.ForMember(x => x.FirmName, opts => opts.MapFrom(p => p.Firm.Name))
				.ForMember(x => x.Comments, opts => opts.MapFrom(p => p.Comments));
		}
	}
}
