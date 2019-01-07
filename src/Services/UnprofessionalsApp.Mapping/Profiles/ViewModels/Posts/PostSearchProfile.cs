using AutoMapper;
using System.Globalization;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.ViewModels.Home;

namespace UnprofessionalsApp.Mapping.Profiles.Posts
{
	public class PostSearchProfile : Profile
	{
		public PostSearchProfile()
		{
			CreateMap<Post, PostSearchViewModel>()
				.ForMember(x => x.Username, opts => opts.MapFrom(p => p.User.UserName))
				.ForMember(x => x.DateOfCreation, opts => opts.MapFrom(p => p.DateOfCreation.ToString(@"dd/MM/yyyy", CultureInfo.InvariantCulture)));
		}
	}
}
