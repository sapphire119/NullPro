﻿using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using UnprofessionalsApp.Common;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.Mapping;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.ViewModels;
using UnprofessionalsApp.ViewInputModels.ViewModels.Firms;

namespace UnprofessionalsApp.DataServices
{
	public class FirmsService : IFirmsService
	{
		private readonly IRepository<Firm> firmsRepository;

		public FirmsService(IRepository<Firm> firmsRepository)
		{
			this.firmsRepository = firmsRepository;
		}

		public Task<int> GetAllFirmsCount()
		{
			//TODO: Test Me
			var result = Task.Run(() => this.firmsRepository.All().Count());
			return result;
		}

		//public IEnumerable<FirmViewModel> GetAllFirmsForCurrentPage(int currentPage, int pageSize)
		//{
		//	//TODO: Test Me
		//	var firmsForCurrentPage = this.firmsRepository.All()
		//		.OrderBy(d => d.Id)
		//		.Skip((currentPage - 1) * pageSize)
		//		.Take(pageSize)
		//		.To<FirmViewModel>()
		//		.ToList();

		//	return firmsForCurrentPage;
		//}

		public Task<IEnumerable<FirmViewModel>> GetAllFirmsForCurrentPage(
			int currentPage, 
			int pageSize, 
			string orderByParam, 
			string ordering)
		{
			//Test And Validate Me.
			var firmsForCurrentPage = Task.Run(() => this.firmsRepository.All()
				.AsQueryable() // Вече е IQueryable, но за всеки случай
				.OrderBy(string.Concat(orderByParam, $" {ordering}"))
				.ThenBy(f => f.Posts.Count())
				.Skip((currentPage - 1) * pageSize)
				.Take(pageSize)
				.To<FirmViewModel>() as IEnumerable<FirmViewModel>);

			return firmsForCurrentPage;
		}

		public Task<TViewModel> GetFirmById<TViewModel>(int id)
		{
			throw new System.NotImplementedException();
		}
	}
}
