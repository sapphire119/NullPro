using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UnprofessionalsApp.Models;

namespace UnprofessionalsApp.Mapping.Profiles.DataTransferObjects.Images
{
	public class CreateImageProfile : Profile
	{
		public CreateImageProfile()
		{
			CreateMap<string, Image>()
				.ForMember(x => x.Url, opts => opts.MapFrom(x => x));
		}
	}
}
