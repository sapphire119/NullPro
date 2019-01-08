using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnprofessionalsApp.Models;

namespace UnprofessionalsApp.DataServices.Contracts
{
	public interface ITagsService
	{
		Task<IEnumerable<Tag>> CreateTags(string tags);

		Task<IEnumerable<Tag>> RemoveDuplicates(IEnumerable<Tag> tags);
	}
}
