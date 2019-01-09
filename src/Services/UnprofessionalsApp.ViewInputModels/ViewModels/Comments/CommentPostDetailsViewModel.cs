using System;
using System.Collections.Generic;
//using System.Text;
//using AutoMapper;
////using UnprofessionalsApp.Mapping.Contracts;
//using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.ViewModels.Replies;

namespace UnprofessionalsApp.ViewInputModels.ViewModels.Comments
{
	public class CommentPostDetailsViewModel /*: IMapFrom<Comment>, IHaveCustomMappings*/
	{
		public int Id { get; set; }

		public string Description { get; set; }

		public DateTime DateOfCreation { get; set; }

		public int UserId { get; set; }

		public string Username { get; set; }

		public string UserImageUrl { get; set; }

		public bool IsDeleted { get; set; }

		public int PostId { get; set; }

		public IEnumerable<ReplyPostDetailsViewModel> Replies { get; set; }

		//public void CreateMappings(IMapperConfigurationExpression configuration)
		//{
		//	configuration.CreateMap<Comment, CommentPostDetailsViewModel>()
		//		.ForMember(c => c.Username, opts => opts.MapFrom(c => c.User.UserName));
		//}
	}
}