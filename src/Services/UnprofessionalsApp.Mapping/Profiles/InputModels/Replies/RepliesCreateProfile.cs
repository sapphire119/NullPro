using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.InputModels.Replies;

namespace UnprofessionalsApp.Mapping.Profiles.InputModels.Replies
{
	public class RepliesCreateProfile : Profile
	{
		public RepliesCreateProfile()
		{
			CreateMap<CreateInputModel, Reply>()
				.ForMember(x => x.Description, opts => opts.MapFrom(x => x.Description.Trim()))
				.ForMember(x => x.UserId, opts => opts.MapFrom(x => x.UserId))
				.ForMember(x => x.CommentId, opts => opts.MapFrom(x => x.CommentId));
		}
	}
}
