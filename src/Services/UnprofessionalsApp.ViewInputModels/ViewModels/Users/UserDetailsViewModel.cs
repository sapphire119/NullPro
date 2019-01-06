using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AutoMapper;
using UnprofessionalsApp.Common;
using UnprofessionalsApp.Mapping.Contracts;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.ViewModels.Comments;
using UnprofessionalsApp.ViewInputModels.ViewModels.Posts;

namespace UnprofessionalsApp.ViewInputModels.ViewModels.Users
{
	public class UserDetailsViewModel : IMapFrom<UnprofessionalsAppUser>, IHaveCustomMappings
	{
		private string description;
		private string email;
		private string phoneNumber;
		private IEnumerable<PostUserDetailsViewModel> posts;
		private IEnumerable<PostUserDetailsViewModel> firmPosts;
		IEnumerable<CommentUserDetailsViewModel> comments;

		public int Id { get; set; }

		public string Username { get; set; }

		public string Description
		{
			get
			{
				//TODO: Test me
				if (this.description == null)
				{
					return GlobalConstants.NoDescriptionForUser;
				}

				return this.description;
			}
			set
			{
				this.description = value;
			}
		}

		public string Email
		{
			get
			{
				//TODO: Test me
				if (this.email == null)
				{
					return GlobalConstants.NoEmailForUser;
				}

				return this.email;
			}
			set
			{
				this.email = value;
			}
		}

		public string PhoneNumber
		{
			get
			{
				//TODO: Test me
				if (this.phoneNumber == null)
				{
					return GlobalConstants.NoPhoneNumberForUser;
				}

				return this.phoneNumber;
			}
			set
			{
				this.phoneNumber = value;
			}
		}

		public string DateOfRegistration { get; set; }

		public IEnumerable<PostUserDetailsViewModel> FirmPosts
		{
			get
			{
				return this.firmPosts.Take(GlobalConstants.EntitiesPerPageLimit);
			}
			set
			{
				this.firmPosts = value;
			}
		}

		public IEnumerable<PostUserDetailsViewModel> Posts
		{
			get
			{
				return this.posts.Take(GlobalConstants.EntitiesPerPageLimit);
			}
			set
			{
				this.posts = value;
			}
		}

		public IEnumerable<CommentUserDetailsViewModel> Comments
		{
			get
			{
				return this.comments.Take(GlobalConstants.EntitiesPerPageLimit);
			}
			set
			{
				this.comments = value;
			}
		}

		public void CreateMappings(IMapperConfigurationExpression configuration)
		{
			configuration.CreateMap<UnprofessionalsAppUser, UserDetailsViewModel>()
				.ForMember(x => x.Username, opts => opts.MapFrom(x => x.UserName))
				.ForMember(x => x.Email, opts => opts.MapFrom(x => x.Email))
				.ForMember(x => x.PhoneNumber, opts => opts.MapFrom(x => x.PhoneNumber))
				.ForMember(x => x.FirmPosts, 
						opts => opts.MapFrom(
									x => x.Posts
										  .Where(p => p.FirmId != null)
										  .OrderByDescending(p => p.DateOfCreation)
										  .Select(c => c)))
				.ForMember(x => x.Posts, 
						opts => opts.MapFrom(
									x => x.Posts
										  .Where(p => p.FirmId == null)
										  .OrderByDescending(p => p.DateOfCreation)
										  .Select(c => c)))
				.ForMember(x => x.Comments,
						opts => opts.MapFrom(
									x => x.Comments
										  .OrderByDescending(p => p.DateOfCreation)
										  .Select(c => c)))
				.ForMember(x => x.DateOfRegistration, 
						opts => opts.MapFrom(
									u => u.DateOfRegistration
										  .ToString(@"dd/MM/yyyy", CultureInfo.InvariantCulture)));
		}
	}
}
