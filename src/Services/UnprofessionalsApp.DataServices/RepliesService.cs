using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using UnprofessionalsApp.Common;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.InputModels.Replies;

using AutoMapper;
using System.Linq;

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

		public async Task<int> DeleteReply(ReplyEntityInputModel inputModel)
		{
			var currentReply = this.repliesRepository.All()
					.Where(c => c.Id == inputModel.Id)
					.FirstOrDefault();

			if (currentReply == null)
			{
				return default(int);
			}

			currentReply.IsDeleted = true;

			var statusCode = await this.repliesRepository.SaveChangesAsync();

			return statusCode;
		}

		public Task<TViewModel> GetReplyByIdAsync<TViewModel>(int commentId)
		{
			var replyTask = Task.Run(() =>
			{
				var source = this.repliesRepository.All().Where(c => c.Id == commentId);

				var destination = this.mapper.ProjectTo<TViewModel>(source);

				var result = destination.FirstOrDefault();

				return result;
			});

			return replyTask;
		}
	}
}
