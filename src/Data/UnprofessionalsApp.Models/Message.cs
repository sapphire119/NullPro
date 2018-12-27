namespace UnprofessionalsApp.Models
{
	using System;
	using UnprofessionalsApp.Common;

	public class Message : BaseModel<int>
	{
		public string Description { get; set; }

		public DateTime DateOfCreation { get; set; } = DateTime.UtcNow;

		public int SenderId { get; set; }

		public virtual UnprofessionalsAppUser Sender { get; set; }

		public int ReceiverId { get; set; }

		public virtual UnprofessionalsAppUser Reciever { get; set; }

	}
}
