using System;
using System.Collections.Generic;
using System.Text;
using UnprofessionalsApp.Common;

namespace UnprofessionalsApp.Models
{
	public class Image : BaseModel<int>
	{
		public string Url { get; set; }

		public virtual ICollection<UnprofessionalsAppUser> Users { get; set; } = new HashSet<UnprofessionalsAppUser>();

		public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();
	}
}
