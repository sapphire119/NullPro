using System.Collections.Generic;
using UnprofessionalsApp.Common;

namespace UnprofessionalsApp.Models
{
	public class Firm : BaseModel<int>
	{
		//Bulstat, EIP, PIK
		public string UniqueFirmId { get; set; }

		public string Name { get; set; }

		public int Popularity { get; set; }

		public decimal Rating { get; set; }

		public string UrlToTradersRegistry { get; set; }

		public bool IsBlackListed { get; set; } = false;

		public int? CategoryId { get; set; }

		public virtual Category Category { get; set; }

		public int UserId { get; set; }

		public virtual UnprofessionalsAppUser User { get; set; }

		public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();
	}
}
