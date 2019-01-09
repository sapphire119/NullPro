using System;
using System.Linq;
using System.Collections.Generic;
using UnprofessionalsApp.Common;

namespace UnprofessionalsApp.Models
{
	public class Firm : BaseModel<Guid>
	{
		//Bulstat, EIP, PIK
		public string UniqueFirmId { get; set; }

		public string Name { get; set; }

		public bool IsBlackListed { get; set; } = false;

		public bool IsDeleted { get; set; } = false;

		public DateTime DateOfRegistration { get; set; } = DateTime.UtcNow;

		public string LegalForm { get; set; }

		public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();

		public virtual ICollection<Report> Reports { get; set; } = new HashSet<Report>();
	}
}
