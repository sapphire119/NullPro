namespace UnprofessionalsApp.ViewInputModels.ViewModels.Home
{
	using System;
	using System.Globalization;
	using AutoMapper;
	using UnprofessionalsApp.Mapping.Contracts;
	using UnprofessionalsApp.Models;

	public class PostSearchViewModel : IMapFrom<Post>, IHaveCustomMappings
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string DateOfCreation { get; set; }

		public int UserId { get; set; }

		public string Username { get; set; }

		public void CreateMappings(IMapperConfigurationExpression configuration)
		{
			configuration.CreateMap<Post, PostSearchViewModel>()
				.ForMember(x => x.Username, opts => opts.MapFrom(p => p.User.UserName))
				.ForMember(x => x.DateOfCreation, opts => opts.MapFrom(p => p.DateOfCreation.ToString(@"dd/MM/yyyy", CultureInfo.InvariantCulture)));
		}
	}
}
