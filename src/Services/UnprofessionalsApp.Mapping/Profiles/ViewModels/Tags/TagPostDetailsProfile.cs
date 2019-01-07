using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.ViewModels.Tags;

namespace UnprofessionalsApp.Mapping.Profiles.Tags
{
	public class TagPostDetailsProfile : Profile
	{
		public TagPostDetailsProfile()
		{
			CreateMap<TagPost, TagPostDetailsViewModel>()
				.ForMember(t => t.Id, opts => opts.MapFrom(t => t.TagId))
				.ForMember(t => t.Name, opts => opts.MapFrom(t => t.Tag.Name));
		}
	}
}
