using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UnprofessionalsApp.Models;

namespace UnprofessionalsApp.Mapping.Profiles.InputModels.Comments
{
	public class CommentDeleteProfile : Profile
	{
		public CommentDeleteProfile()
		{
			CreateMap<CommentDeleteProfile, Comment>();
		}
	}
}
