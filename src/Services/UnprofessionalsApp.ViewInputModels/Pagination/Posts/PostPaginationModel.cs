using System;
using System.Collections.Generic;
using System.Text;
using UnprofessionalsApp.CustomAttributes;

namespace UnprofessionalsApp.ViewInputModels.Pagination.Reports
{
	public class PostPaginationModel
	{
		private int totalPages;

		public int CurrentPage { get; set; } = 1;

		[Pagination("10")]
		public int PageSize { get; set; } = 10;

		[Pagination("Id, Title, DateOfCreation")]
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
