using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.ViewModels.Comments;
using AutoMapper;

namespace UnprofessionalsApp.Mapping.Profiles.Comments
{
	public class ComentPostDetailsProfile : Profile
	{
		public ComentPostDetailsProfile()
		{
			CreateMap<Comment, CommentPostDetailsViewModel>()
				.ForMember(c => c.Username, opts => opts.MapFrom(c => c.User.UserName))
				.ForMember(c => c.Replies,
						opts => opts.MapFrom(
								c => c.Replies
									  .OrderBy(r => r.DateOfCreation)
									  .Select(r => r)));
		}
	}
}
