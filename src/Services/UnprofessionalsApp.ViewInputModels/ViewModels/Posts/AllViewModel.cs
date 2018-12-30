namespace UnprofessionalsApp.ViewInputModels.ViewModels.Posts
{
	using System;
	using System.Globalization;
	using System.Net;
	using AutoMapper;
	using UnprofessionalsApp.Mapping.Contracts;
	using UnprofessionalsApp.Models;
	using UnprofessionalsApp.ViewInputModels.Extension;

	public class AllViewModel : IMapFrom<Post>, IHaveCustomMappings
	{
		private string imageUrl;
		private string dateOfCreation;

		public int Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public string DateOfCreation { get; set; }

		public int UserId { get; set; }

		public string ImageUrl
		{
			get
			{
				return this.imageUrl;
			}
			set
			{
				this.imageUrl = WebUtility.UrlDecode(value);
			}
		}

		public void CreateMappings(IMapperConfigurationExpression configuration)
		{
			//TODO: Test me somehow
			configuration.CreateMap<Post, AllViewModel>()
				.ForMember(x => x.DateOfCreation,
					x => x.MapFrom(
							p => p.DateOfCreation.ToString(@"d MMMM, yyyy", CultureInfo.InvariantCulture)))
				.ForMember(x => x.Description, 
					x => x.MapFrom(
							p => p.Description.Length > ProjectConsants.AllowedCharactersToRender ?
								string.Concat(
									p.Description.Substring(0, ProjectConsants.AllowedCharactersToRender),
									ProjectConsants.DescriptionExtensionStrings) 
										: p.Description));
		}
	}
}
