using System;
using System.Collections.Generic;
using System.Text;
using UnprofessionalsApp.Models;

namespace UnprofessionalsApp.DataTransferObjects.Posts
{
	public class PostCreateDto
	{
		public string Title { get; set; }

		public string Description { get; set; }

		public int ImageId { get; set; }

		public int CategoryId { get; set; }

		public int UsernId { get; set; }

		//public IEnumerable<Tag> Tags { get; set; }
	}
}
