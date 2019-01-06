using System;
using AutoMapper;
using UnprofessionalsApp.Mapping.Contracts;
using UnprofessionalsApp.Models;

namespace UnprofessionalsApp.ViewInputModels.ViewModels.Replies
{
	public class ReplyPostDetailsViewModel : IMapFrom<Reply>, IHaveCustomMappings
	{
		public int Id { get; set; }

		public string Description { get; set; }

		public DateTime DateOfCreation { get; set; }

		public int CommentId { get; set; }

		public int UserId { get; set; }

		public string Username { get; set; }

		public void CreateMappings(IMapperConfigurationExpression configuration)
		{
			configuration.CreateMap<Reply, ReplyPostDetailsViewModel>()
				.ForMember(r => r.Username, opts => opts.MapFrom(r => r.User.UserName));
		}
	}
}
