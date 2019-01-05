using System;
using AutoMapper;
using UnprofessionalsApp.Mapping.Contracts;
using UnprofessionalsApp.Models;

namespace UnprofessionalsApp.ViewInputModels.ViewModels.Home
{
	public class PostSearchViewModel : IMapFrom<Post>, IHaveCustomMappings
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public DateTime DateOfCreation { get; set; }

		public int UserId { get; set; }

		public string Username { get; set; }

		public void CreateMappings(IMapperConfigurationExpression configuration)
		{
			configuration.CreateMap<Post, PostSearchViewModel>()
				.ForMember(x => x.Username, opts => opts.MapFrom(p => p.User.UserName));
		}
	}
}
