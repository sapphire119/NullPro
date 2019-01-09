using System.Collections.Generic;
using UnprofessionalsApp.Common;

namespace UnprofessionalsApp.Models
{
	public class Category : BaseModel<int>
	{
		public string Name { get; set; }

		public bool IsDeleted { get; set; } = false;

		public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();
	}
}
