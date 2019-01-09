using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.ViewModels.Reports;

namespace UnprofessionalsApp.Mapping.Profiles.InputModels.Reports
{
	public class ReportViewProfile : Profile
	{
		public ReportViewProfile()
		{
			CreateMap<Report, ReportViewModel>()
				.ForMember(x => x.CreationDate, opts =>
					opts.MapFrom(r => r.CreationDate.ToString(@"dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture)))
				.ForMember(x => x.UserId, opts => opts.MapFrom(x => x.UserId))
				.ForMember(x => x.Username, opts => opts.MapFrom(x => x.User.UserName));
		}
	}
}
