using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnprofessionalsApp.Common;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.Models;

namespace UnprofessionalsApp.DataServices
{
	public class CommentsService : ICommentsService
	{
		private readonly IRepository<Comment> commentsRepository;
		private readonly IMapper mapper;

		public CommentsService(IRepository<Comment> commentsRepository, IMapper mapper)
		{
			this.commentsRepository = commentsRepository;
			this.mapper = mapper;
		}

		public async Task CreateComment<T>(T inputModel)
		{
			var comment = this.mapper.Map<Comment>(inputModel);

			await this.commentsRepository.AddAsync(comment);

			throw new NotImplementedException();
		}
	}
}
