using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace UnprofessionalsApp.CustomAttributes
{
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class PaginationAttribute : ValidationAttribute
	{
		private List<string> AllowedExtensions { get; set; }

		public PaginationAttribute(string filters)
		{
			this.AllowedExtensions = filters.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
				.Select(v => v.Trim())
				.ToList();
		}

		public override bool IsValid(object value)
		{
			var valueString = value.ToString();

			if (valueString != null)
			{
				var result = this.AllowedExtensions.Any(e => e.ToLower() == valueString.ToLower());

				return result;
			}

			return false;
		}
	}
}
