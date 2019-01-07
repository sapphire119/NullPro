using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.ViewModels.Comments;

namespace UnprofessionalsApp.Mapping.Profiles.Comments
{
	public class ComentPostDetailsProfile : Profile
	{
		public ComentPostDetailsProfile()
		{
			CreateMap<Comment, CommentPostDetailsViewModel>()
				.ForMember(c => c.Username, opts => opts.MapFrom(c => c.User.UserName));
		}
	}
}
