using UnprofessionalsApp.Mapping.Contracts;
using UnprofessionalsApp.Models;

namespace UnprofessionalsApp.ViewInputModels.ViewModels.Tags
{
	public class TagViewModel : IMapFrom<Tag>
	{
		public int Id { get; set; }

		public string Name { get; set; }

	}
}
