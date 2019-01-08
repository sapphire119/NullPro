using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.Common;

namespace UnprofessionalsApp.DataServices
{
	public class TagsService : ITagsService
	{
		private readonly IRepository<Tag> tagsRepository;

		public TagsService(IRepository<Tag> tagsRepository)
		{
			this.tagsRepository = tagsRepository;
		}

		public Task<IEnumerable<Tag>> RemoveDuplicates(IEnumerable<Tag> tags)
		{
			var resultingTagsTask = Task.Run(() =>
			{
				var result = tags.Where(t => !this.tagsRepository.All().Any(it => it.Name == t.Name));

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
	}
}
