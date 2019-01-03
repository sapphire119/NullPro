using UnprofessionalsApp.Mapping.Contracts;
using UnprofessionalsApp.Models;

namespace UnprofessionalsApp.ViewInputModels.ViewModels.Categories
{
	public class CategoryViewModel : IMapFrom<Category>
	{
		public int Id { get; set; }

		public string Name { get; set; }
	}
}
