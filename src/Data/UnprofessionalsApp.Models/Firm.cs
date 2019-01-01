using System;
using System.Collections.Generic;
using UnprofessionalsApp.Common;

namespace UnprofessionalsApp.Models
{
	public class Firm : BaseModel<Guid>
	{
		//Bulstat, EIP, PIK
		public string UniqueFirmId { get; set; }

		public string Name { get; set; }
		
		public int Popularity { get; set; }

		public int Rating { get; set; }

		public string LegalForm { get; set; }

		public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();

		public virtual ICollection<Report> Reports { get; set; } = new HashSet<Report>();
	}
}
