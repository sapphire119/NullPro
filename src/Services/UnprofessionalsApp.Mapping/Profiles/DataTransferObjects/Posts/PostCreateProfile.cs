using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using UnprofessionalsApp.DataTransferObjects.Posts;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.InputModels.Posts;

namespace UnprofessionalsApp.Mapping.Profiles.DataTransferObjects.Posts
{
	public class PostCreateProfile : Profile
	{
		public PostCreateProfile()
		{
			CreateMap<PostCreateInputModel, PostCreateDto>()
				.ForMember(x => x.ImageId, opts => opts.Ignore())
				.ForMember(x => x.FirmUniqueId, opts => opts.MapFrom(x => x.FirmUniqueId))
				//.ForMember(x => x.Tags, opts => opts.Ignore())
				.ForMember(x => x.Title, opts => opts.MapFrom(x => x.Title))
				.ForMember(x => x.Description, opts => opts.MapFrom(x => x.Description))
				.ForMember(x => x.CategoryId, opts => opts.MapFrom(x => x.CategoryId));

			CreateMap<PostCreateDto, Post>()
				.ForMember(x => x.ImageId, opts => opts.MapFrom(x => x.ImageId))
				.ForMember(x => x.Title, opts => opts.MapFrom(x => x.Title))
				.ForMember(x => x.Description, opts => opts.MapFrom(x => x.Description))
				.ForMember(x => x.CategoryId, opts => opts.MapFrom(x => x.CategoryId))
				.ForMember(x => x.UserId, opts => opts.MapFrom(x => x.UsernId));
				//.ForMember(x => x.unique, opts => opts.MapFrom(x => x.UsernId));
				//.ForMember(x => x.Tags, opts => opts.MapFrom(x => x.Tags.Select(t => t)));
		}
	}
}
