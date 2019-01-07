﻿using AutoMapper;
using System.Globalization;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.ViewModels.Categories;

namespace UnprofessionalsApp.Mapping.Profiles.Categories
{
	public class PostByCategoryProfile : Profile
	{
		public PostByCategoryProfile()
		{
			CreateMap<Post, PostByCategoryViewModel>()
					.ForMember(x => x.Username, opts => opts.MapFrom(p => p.User.UserName))
					.ForMember(x => x.DateOfCreation, opts => opts.MapFrom(p => p.DateOfCreation.ToString(@"dd/MM/yyyy", CultureInfo.InvariantCulture)));
		}
	}
}
