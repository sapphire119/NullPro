using AutoMapper;
namespace UnprofessionalsApp.Mapping.Profiles.Comments
{
	using System.Globalization;
	using UnprofessionalsApp.Models;
	using UnprofessionalsApp.ViewInputModels.ViewModels.Comments;

	public class CommentUserDetailsProfile : Profile
	{
		public CommentUserDetailsProfile()
		{
			CreateMap<Comment, CommentUserDetailsViewModel>()
				.ForMember(x => x.DateOfCreation, opts => opts.MapFrom(c => c.DateOfCreation.ToString(@"d MMMM yyyy", CultureInfo.InvariantCulture)))
				.ForMember(x => x.PostTitle, opts => opts.MapFrom(c => c.Post.Title));
		}
	}
}
