using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.ViewModels.Comments;

namespace UnprofessionalsApp.Mapping.Profiles.ViewModels.Comments
{
	class CommentUserProfileProfile : Profile
	{
		public CommentUserProfileProfile()
		{
			CreateMap<Comment, CommentUserProfileViewModel>()
				.ForMember(x => x.DateOfCreation,
					opts => opts.MapFrom(
							c => c.DateOfCreation
								  .ToLocalTime()
								  .ToString(@"dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture)))
				.ForMember(x => x.PostTitle, opts => opts.MapFrom(c => c.Post.Title));
		}
	}
}
