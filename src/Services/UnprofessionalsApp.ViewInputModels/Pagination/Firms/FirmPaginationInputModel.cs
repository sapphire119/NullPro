using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UnprofessionalsApp.CustomAttributes;
using UnprofessionalsApp.ViewInputModels.ViewModels.Firms;

namespace UnprofessionalsApp.ViewInputModels.InputModels.Pagination
{
	public class FirmPaginationInputModel 
	{
		private int totalPages;

		public int CurrentPage { get; set; } = 1;

		[Pagination("10, 20, 50")]
		public int PageSize { get; set; } = 10;

		[Pagination("Id, Name, DateOfRegistration, PostsAboutFirm")]
		public string SortBy { get; set; }

		[Pagination("ascending, descending")]
		public string Ordering { get; set; }
		
		public int ResultPerPage { get; set; } = 10;

		public int Count { get; set; }

		public int TotalPages
		{
			get
			{
				this.totalPages = (int)Math.Ceiling(decimal.Divide(this.Count, this.PageSize));

				return this.totalPages;
			}
			set
			{
				this.totalPages = value;
			}
		}
	}
}
