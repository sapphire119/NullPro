using AutoMapper;
using System.Globalization;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.ViewModels.Posts;

namespace UnprofessionalsApp.Mapping.Profiles.Posts
{
	public class PostViewProfile : Profile
	{
		public PostViewProfile()
		{
			CreateMap<Post, PostViewModel>()
				.ForMember(x => x.ImageUrl, opts => opts.MapFrom(x => x.Image.Url))
				.ForMember(x => x.DateOfCreation, 
					opts => opts.MapFrom(p => p.DateOfCreation.ToString(@"d MMMM, yyyy", CultureInfo.InvariantCulture)))
				.ForMember(x => x.Username, opts => opts.MapFrom(p => p.User.UserName));
		}
	}
}
