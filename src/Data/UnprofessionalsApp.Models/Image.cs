using System;
using System.Collections.Generic;
using System.Text;
using UnprofessionalsApp.Common;

namespace UnprofessionalsApp.Models
{
	public class Image : BaseModel<int>
	{
		public string Url { get; set; }

		public ICollection<UnprofessionalsAppUser> Users { get; set; }

		public ICollection<Post> Posts { get; set; }
	}
}
