using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UnprofessionalsApp.DataTransferObjects.Reoorts;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.InputModels.Reports;

namespace UnprofessionalsApp.Mapping.Profiles.DataTransferObjects.Reports
{
	public class ReportCreateProfile : Profile
	{
		public ReportCreateProfile()
		{
			CreateMap<ReporCreateInputModel, ReportCreateDto>()
				.ForMember(x => x.UserId, opts => opts.Ignore())
				.ForMember(x => x.FirmId, opts => opts.Ignore());

			CreateMap<ReportCreateDto, Report>()
				.ForMember(x => x.Description, opts => opts.MapFrom(x => x.Description))
				.ForMember(x => x.UserId, opts => opts.MapFrom(x => x.UserId));
		}
	}
}
