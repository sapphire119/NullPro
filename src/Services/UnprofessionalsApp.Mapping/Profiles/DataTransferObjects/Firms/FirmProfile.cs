using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UnprofessionalsApp.Models;

namespace UnprofessionalsApp.Mapping.Profiles.DataTransferObjects.Firms
{
	public class FirmProfile : Profile
	{
		public FirmProfile()
		{
			CreateMap<Firm, Firm>();
		}
	}
}
