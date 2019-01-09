using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.InputModels.Reports;

namespace UnprofessionalsApp.Mapping.Profiles.InputModels.Reports
{
	public class ReportEnityProfile : Profile
	{
		public ReportEnityProfile()
		{
			CreateMap<ReportEntityInputModel, Report>();

			CreateMap<Report, ReportEntityInputModel>()
				.ForMember(x => x.Username, opts => opts.MapFrom(x => x.User.UserName));
		}
	}
}
