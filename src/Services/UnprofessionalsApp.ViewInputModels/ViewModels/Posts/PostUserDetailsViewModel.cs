using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using UnprofessionalsApp.Common;
using UnprofessionalsApp.Mapping.Contracts;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.ViewModels.Tags;

namespace UnprofessionalsApp.ViewInputModels.ViewModels.Posts
{
	public class PostUserDetailsViewModel : IMapFrom<Post>, IHaveCustomMappings
	{
		private string description;

		public int Id { get; set; }

		public string Title { get; set; }

		public string Description
		{
			get
			{
				if (this.description.Length > GlobalConstants.AllowedCharactersToRenderForPostDetailsDescription)
				{
					var result = string.Concat(
						this.description.Substring(0, GlobalConstants.AllowedCharactersToRenderForPostDetailsDescription),
						GlobalConstants.DescriptionExtensionStrings);

					return result;
				}

				return this.description;
			}
			set
			{
				this.description = value;
			}
		}

		public string DateOfCreation { get; set; }

		public IEnumerable<TagPostDetailsViewModel> Tags { get; set; }

		public void CreateMappings(IMapperConfigurationExpression configuration)
		{
			configuration.CreateMap<Post, PostUserDetailsViewModel>()
				.ForMember(x => x.DateOfCreation, opts => opts.MapFrom(p => p.DateOfCreation.ToString(@"dd/MM/yyyy", CultureInfo.InvariantCulture)));
		}
	}
}
