using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UnprofessionalsApp.ViewInputModels.InputModels.Reports
{
	public class ReportEntityInputModel
	{
		public int Id { get; set; }

		public string Description { get; set; }

		public int UserId { get; set; }

		[Display(Name = "Made by Username: ")]
		public string Username { get; set; }
	}
}
