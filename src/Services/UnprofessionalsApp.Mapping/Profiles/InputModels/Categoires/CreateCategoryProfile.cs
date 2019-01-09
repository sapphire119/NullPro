using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.InputModels.Categories;

namespace UnprofessionalsApp.Mapping.Profiles.InputModels.Categoires
{
	public class CreateCategoryProfile : Profile
	{
		public CreateCategoryProfile()
		{
			CreateMap<CreateCategoryInputModel, Category>()
				.ForMember(x => x.Name, opts => opts.MapFrom(x => x.Name))
				.ForMember(x => x.IsDeleted, opts => opts.Ignore());
		}
	}
}
