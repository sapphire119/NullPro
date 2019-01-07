using AutoMapper;
using System.Globalization;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.ViewModels.Posts;

namespace UnprofessionalsApp.Mapping.Profiles.Posts
{
	public class PostEntityProfile : Profile
	{
		public PostEntityProfile()
		{
			CreateMap<Post, PostEntityDetailsViewModel>()
				.ForMember(x => x.DateOfCreation, opts => opts.MapFrom(p => p.DateOfCreation.ToString(@"dd/MM/yyyy", CultureInfo.InvariantCulture)));
		}
	}
}
