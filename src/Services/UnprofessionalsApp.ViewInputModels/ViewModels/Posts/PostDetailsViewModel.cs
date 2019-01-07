namespace UnprofessionalsApp.ViewInputModels.ViewModels.Posts
{
	using System;
	using System.Collections.Generic;
	using System.Net;
	using System.Globalization;
	using System.Linq;
	//using AutoMapper;

	//using UnprofessionalsApp.Mapping.Contracts;
	//using UnprofessionalsApp.Models;
	using UnprofessionalsApp.ViewInputModels.ViewModels.Tags;
	using UnprofessionalsApp.ViewInputModels.ViewModels.Comments;
	using UnprofessionalsApp.Common;

	public class PostDetailsViewModel /*: IMapFrom<Post>, IHaveCustomMappings*/
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
					GlobalConstants.DefaultImageUrl : this.imageUrl;

				result = WebUtility.UrlDecode(result);

				return result;
			}
			set
			{
				this.imageUrl = value;
			}
		}

		public string DateOfCreation { get; set; }

		public int UserId { get; set; }

		public string Username { get; set; }

		public int CategoryId { get; set; }

		public Guid? FirmId { get; set; }

		public string FirmName { get; set; }

		public IEnumerable<CommentPostDetailsViewModel> Comments { get; set; }

		public IEnumerable<TagPostDetailsViewModel> Tags{ get; set; }

		//public void CreateMappings(IMapperConfigurationExpression configuration)
		//{
		//	configuration.CreateMap<Post, PostDetailsViewModel>()
		//		.ForMember(x => x.Username, opts => opts.MapFrom(p => p.User.UserName))
		//		.ForMember(x => x.FirmName, opts => opts.MapFrom(p => p.Firm.Name))
		//		.ForMember(x => x.Comments, opts => opts.MapFrom(p => p.Comments))
		//		.ForMember(x => x.DateOfCreation, opts => opts.MapFrom(p => 
		//		string.Format(
		//			GlobalConstants.PostDetailsDateOfCreationFormat,
		//			p.DateOfCreation.ToString(@"d MMMM yyyy", CultureInfo.InvariantCulture),
		//			p.DateOfCreation.ToString(@"hh:mm tt", CultureInfo.InvariantCulture))));
		//}
	}
}
