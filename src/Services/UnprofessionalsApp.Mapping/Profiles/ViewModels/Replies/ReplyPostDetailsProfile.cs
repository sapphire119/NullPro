using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.ViewModels.Replies;

namespace UnprofessionalsApp.Mapping.Profiles.Replies
{
	public class ReplyPostDetailsProfile : Profile
	{
		public ReplyPostDetailsProfile()
		{
			CreateMap<Reply, ReplyPostDetailsViewModel>()
				.ForMember(r => r.Username, opts => opts.MapFrom(r => r.User.UserName));
		}
	}
}
