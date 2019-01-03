using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using UnprofessionalsApp.Mapping.Contracts;
using UnprofessionalsApp.Models;

namespace UnprofessionalsApp.ViewInputModels.ViewModels.Posts
{
	public class PostDetailsViewModel : IMapFrom<Post>, IHaveCustomMappings
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public string ImageUrl { get; set; }

		public int Popularity { get; set; }

		public int Rating { get; set; }

		public DateTime DateOfCreation { get; set; }

		public int UserId { get; set; }

		public string Username { get; set; }

		public int CategoryId { get; set; }

		public Guid? FirmId { get; set; }

		public IEnumerable<Tag> Tags { get; set; }

		public void CreateMappings(IMapperConfigurationExpression configuration)
		{
			configuration.CreateMap<Post, PostDetailsViewModel>()
				.ForMember(x => x.Username, opts => opts.MapFrom(p => p.User.UserName))
				.ForMember(x => x.Tags, opts => opts.MapFrom(p =>p.Tags.Select(t => t.Tag)));
		}
	}
}
