using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.InputModels.Reports;

namespace UnprofessionalsApp.Mapping.Profiles.InputModels.Reports
{
	public class ReportCreateProfile : Profile
	{
		public ReportCreateProfile()
		{
			CreateMap<ReporCreateInputModel, Report>()
				.ForMember(x => x.Description, opts => opts.MapFrom(x => x.Description))
				.ForMember(x => x.IsDeleted, opts => opts.Ignore());
		}
	}
}
