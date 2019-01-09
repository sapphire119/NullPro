using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.Common;
using AutoMapper;

namespace UnprofessionalsApp.DataServices
{
	public class TagsService : ITagsService
	{
		private readonly IRepository<Tag> tagsRepository;
		private readonly IMapper mapper;

		public TagsService(IRepository<Tag> tagsRepository, IMapper mapper)
		{
			this.tagsRepository = tagsRepository;
			this.mapper = mapper;
		}

		public Task<IEnumerable<Tag>> RemoveDuplicates(IEnumerable<Tag> tags)
		{
			var resultingTagsTask = Task.Run(() =>
			{
				var result = tags
				.Where(t => !this.tagsRepository.All().Any(it => it.Name.ToLower() == t.Name.ToLower()))
				.Select(t => t.Name.ToLower())
				.Distinct()
				.Select(tagName => new Tag
				{
					Name = string.Concat(tagName[0].ToString().ToUpper(), tagName.Substring(1))
				});

				return result;
			}); 

			return resultingTagsTask;
		}

		public Task<IEnumerable<Tag>> CreateTags(string tags)
		{
			var currentTagsTask = Task.Run(() =>
			{
				var result = tags.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
							   .Select(tagName => new Tag
							   {
								   Name = tagName.Trim()
							   });

				return result;
			}); 

			return currentTagsTask;
		}

		public Task<IEnumerable<TViewModel>> GetAllTags<TViewModel>()
		{
			var tagsTask = Task.Run(() =>
			{
				var source = this.tagsRepository.All().Where(t => t.IsDeleted == false);

				var destination = this.mapper.ProjectTo<TViewModel>(source);

				var result = destination as IEnumerable<TViewModel>;

				return result;
			});

			return tagsTask;
		}

		public Task<string> GetExistingStartingLettersForAllCategories()
		{
			var lettersForCurrentCategories = Task.Run(() => string.Join("",
				this.tagsRepository.All()
				.Where(t => t.IsDeleted == false)
				.OrderBy(c => c.Name)
				.Select(c => c.Name[0])
				.Distinct()
				.ToArray()).ToUpper());

			return lettersForCurrentCategories;
		}

		public Task<bool> AreThereAnyPostsWithTag(int categoryId)
		{
			var result = Task.Run(() => 
			{
				var areThereAnyPostsForTag = this.tagsRepository.All()
				 .Where(c => c.IsDeleted == false && c.Id == categoryId)
				 .SelectMany(c => c.Posts)
				 .Any();

				return areThereAnyPostsForTag;
			});

			return result;
		}

		public Task<IEnumerable<TViewModel>> GetAllRealtedPosts<TViewModel>(int tagId)
		{
			var relatedPosts = Task.Run(() =>
			{
				var source = this.tagsRepository.All()
						.Where(c => c.Id == tagId)
						.SelectMany(c => c.Posts.Select(t => t.Post))
						//.To<PostByCategoryViewModel>()
						.OrderByDescending(p => p.DateOfCreation)
						.AsQueryable();

				var destination = this.mapper.ProjectTo<TViewModel>(source);

				var result = destination.AsEnumerable();

				return result;
			});

			return relatedPosts;
		}
	}
}
