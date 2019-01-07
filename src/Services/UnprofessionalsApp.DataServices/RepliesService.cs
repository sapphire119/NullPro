using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using UnprofessionalsApp.Common;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.InputModels.Replies;

using AutoMapper;


namespace UnprofessionalsApp.DataServices
{
	public class RepliesService : IRepliesService
	{
		private readonly IRepository<Reply> repliesRepository;
		private readonly IMapper mapper;

		public RepliesService(IRepository<Reply> repliesRepository, IMapper mapper)
		{
			this.repliesRepository = repliesRepository;
			this.mapper = mapper;
		}

		public async Task<int> CreateReply(CreateInputModel replyModel)
		{
			var reply = this.mapper.Map<Reply>(replyModel);

			await this.repliesRepository.AddAsync(reply);

			var statusResult = await this.repliesRepository.SaveChangesAsync();

			return statusResult;
		}
	}
}
