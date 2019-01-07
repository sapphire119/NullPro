using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.InputModels.Posts;

namespace UnprofessionalsApp.Mapping.Profiles.InputModels.Posts
{
	public class PostCreateProfile : Profile
	{
		public PostCreateProfile()
		{
			CreateMap<PostCreateInputModel, Post>()
				.ForMember(x => x.ImageUrl, opts => opts.Ignore())
				.ForMember(x => x.Title, opts => opts.MapFrom(x => x.Title))
				.ForMember(x => x.Description, opts => opts.MapFrom(x => x.Description))
				.ForMember(x => x.CategoryId, opts => opts.MapFrom(x => x.CategoryId));
		}
	}
}
