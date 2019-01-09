using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using UnprofessionalsApp.Common;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.InputModels.Comments;

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

		public async Task<int> CreateComment(CreateInputModel inputModel)
		{
			//TODO: Test with in memeory DB.
			var comment = this.mapper.Map<Comment>(inputModel);

			await this.commentsRepository.AddAsync(comment);

			var statusResult = await this.commentsRepository.SaveChangesAsync();

			return statusResult;
		}

		public async Task<int> DeleteComment(CommentEntityInputModel inputModel)
		{
			var currentComment = this.commentsRepository.All()
					.Where(c => c.Id == inputModel.Id && c.IsDeleted == false)
					.FirstOrDefault();

			if (currentComment == null)
			{
				return default(int);
			}

			currentComment.IsDeleted = true;

			var replies = this.commentsRepository.All()
				.Where(c => c.Id == currentComment.Id && c.IsDeleted == false)
				.SelectMany(p => p.Replies);

			if (replies.Any())
			{
				foreach (var reply in replies)
				{
					reply.IsDeleted = true;
				}
			}

			var statusCode = await this.commentsRepository.SaveChangesAsync();

			return statusCode;
		}

		public async Task<int> EditComment(CommentEntityInputModel inputModel)
		{
			var currentComment = this.commentsRepository.All()
				.Where(c => c.Id == inputModel.Id)
				.FirstOrDefault();

			if (currentComment == null)
			{
				return default(int);
			}

			if (currentComment.Description != inputModel.Description)
			{
				currentComment.Description = inputModel.Description;
			}

			var statusCode = await this.commentsRepository.SaveChangesAsync();

			return statusCode;
		}

		public Task<TViewModel> GetCommentByIdAsync<TViewModel>(int commentId)
		{
			var commentTask = Task.Run(() =>
			{
				var source = this.commentsRepository.All().Where(c => c.Id == commentId);

				var destination = this.mapper.ProjectTo<TViewModel>(source);

				var result = destination.FirstOrDefault();

				return result;
			});

			return commentTask;
		}

		public Task<IEnumerable<TViewModel>> GetCommentsForCurrentUser<TViewModel>(
			UnprofessionalsAppUser currentUser)
		{
			var commentTask = Task.Run(() =>
			{
				var source = this.commentsRepository.All()
				.Where(c => !c.IsDeleted && c.UserId == currentUser.Id);

				var destination = this.mapper.ProjectTo<TViewModel>(source);

				var result = destination as IEnumerable<TViewModel>;

				return result;
			});

			return commentTask;
		}
	}
}
