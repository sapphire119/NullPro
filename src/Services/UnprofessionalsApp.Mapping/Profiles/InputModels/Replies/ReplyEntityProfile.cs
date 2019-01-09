using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.InputModels.Replies;

namespace UnprofessionalsApp.Mapping.Profiles.InputModels.Replies
{
	public class ReplyEntityProfile : Profile
	{
		public ReplyEntityProfile()
		{
			CreateMap<Reply, ReplyEntityInputModel>()
				.ForMember(x => x.CommentId, opts => opts.MapFrom(x => x.CommentId));
		}
	}
}
