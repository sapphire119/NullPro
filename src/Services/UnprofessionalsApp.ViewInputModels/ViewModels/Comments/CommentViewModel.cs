using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using UnprofessionalsApp.Mapping.Contracts;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.ViewModels.Replies;

namespace UnprofessionalsApp.ViewInputModels.ViewModels.Comments
{
	public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
	{
		public int Id { get; set; }

		public string Description { get; set; }

		public int Rating { get; set; }

		public DateTime DateOfCreation { get; set; }

		public int UserId { get; set; }

		public string Username { get; set; }

		public int PostId { get; set; }

		public IEnumerable<ReplyViewModel> Replies { get; set; }

		public void CreateMappings(IMapperConfigurationExpression configuration)
		{
			configuration.CreateMap<Comment, CommentViewModel>()
				.ForMember(c => c.Username, opts => opts.MapFrom(c => c.User.UserName));
		}
	}
}
