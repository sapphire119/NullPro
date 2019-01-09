using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.InputModels.Comments;

namespace UnprofessionalsApp.Mapping.Profiles.InputModels.Comments
{
	public class CommentCreateProfile : Profile
	{
		public CommentCreateProfile()
		{
			CreateMap<CreateInputModel, Comment>()
				.ForMember(x => x.Description, opts => opts.MapFrom(x => x.Description.Trim()))
				.ForMember(x => x.PostId, opts => opts.MapFrom(x => x.PostId))
				.ForMember(x => x.IsDeleted, opts => opts.Ignore())
				.ForMember(x => x.UserId, opts => opts.MapFrom(x => x.UserId));
		}
	}
}
