namespace UnprofessionalsApp.DataServices
{
	using UnprofessionalsApp.Common;
	using UnprofessionalsApp.DataServices.Contracts;
	using UnprofessionalsApp.Models;
	using UnprofessionalsApp.ViewInputModels.ViewModels.Posts;

	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Dynamic.Core;
	//using UnprofessionalsApp.Mapping;
	using System;
	using System.Threading.Tasks;
	using UnprofessionalsApp.ViewInputModels.ViewModels.Comments;
	using UnprofessionalsApp.ViewInputModels.ViewModels.Tags;
	using AutoMapper;
	using Microsoft.Extensions.Configuration;
	using UnprofessionalsApp.ViewInputModels.InputModels.Posts;
	using UnprofessionalsApp.DataTransferObjects.Posts;

	public class PostsService : IPostsService
	{
		private readonly IRepository<Post> postsRepository;
		private readonly IRepository<Tag> tagsRepository;
		private readonly IRepository<TagPost> tagsPostsRepository;
		private readonly IFirmsService firmsService;
		private readonly IMapper mapper;

		public PostsService(IRepository<Post> postsRepository,
			IRepository<Tag> tagsRepository,
			IRepository<TagPost> tagsPostsRepository,
			IFirmsService firmsService,
			IMapper mapper)
		{
			this.postsRepository = postsRepository;
			this.tagsRepository = tagsRepository;
			this.tagsPostsRepository = tagsPostsRepository;
			this.firmsService = firmsService;
			this.mapper = mapper;
		}

		public async Task<int> AddTagsToPost(Post post, IEnumerable<Tag> currentTags)
		{
			foreach (var tag in currentTags)
			{
				await this.tagsPostsRepository.AddAsync(new TagPost { Tag = tag, Post = post });
			}

			var statusCode = await this.tagsPostsRepository.SaveChangesAsync();

			return statusCode;
		}

		public async Task<Post> CreatePost(PostCreateDto postDto)
		{
			var destination = this.mapper.Map<Post>(postDto);

			if (postDto.FirmUniqueId != null)
			{
				destination.FirmId = (await this.firmsService
						.GetFirmByUniqueId<Firm>(postDto.FirmUniqueId)).Id;
			}

			var areThereAnyPostsWithSameTitle =
				this.postsRepository.All().Where(p => p.Title == destination.Title).Any();

			if (areThereAnyPostsWithSameTitle)
			{
				return null;
			}

			await this.postsRepository.AddAsync(destination);

			var statusCode = await this.postsRepository.SaveChangesAsync();

			if (statusCode != GlobalConstants.SuccessfullySavedIntoDbContextStatusCode)
			{
				return null;
			}

			var currentPost = this.postsRepository.All().Where(p => p.Title == destination.Title).FirstOrDefault();

			return currentPost;
		}

		public Task<int> GetAllPostsCount()
		{
			//this.configuration["Cloudinary"]
			//TODO: Test Me
			var result = Task.Run(() =>
			{
				var testResult = this.postsRepository.All().Count();

				return testResult;
			});
			return result;
		}

		public Task<IEnumerable<PostViewModel>> GetAllPostsForCurrentPage(
			int currentPage, int pageSize, string orderByParam, string ordering)
		{
			//var test = this.configuration.GetSection("Cloudinary").GetChildren().ToDictionary(x => x.Key, k => k.Value);
			//TODO: Test me
			var postsViewModel = Task.Run(() =>
			{
				var source = this.postsRepository.All()
				/*.AsQueryable()*/ // Вече е IQueryable, но за всеки случай
				.OrderBy(string.Concat(orderByParam, $" {ordering}"))
				.Skip((currentPage - 1) * pageSize)
				.Take(pageSize);
				//.To<PostViewModel>() as IEnumerable<PostViewModel>

				var destination = this.mapper.ProjectTo<PostViewModel>(source);

				var result = destination as IEnumerable<PostViewModel>;

				return result;
			});

			return postsViewModel;
		}


		//public Task<IEnumerable<CommentPostDetailsViewModel>> GetCommentsAsync(Post post)
		//{
		//	var commentTask = Task.Run(() => this.postsRepository.All()
		//						.Where(p => p.Id == post.Id)
		//						.SelectMany(c => c.Comments.Select(x => x)));
		//}

		public Task<TViewModel> GetPostByIdAsync<TViewModel>(int postId)
		{
			//TODO: Test me
			//TODO: Validate postId
			var postTask = Task.Run(() =>
			{
				var source = this.postsRepository.All()
				.Where(p => p.Id == postId);
				//.To<TViewModel>()
				//.FirstOrDefault()

				var destination = this.mapper.ProjectTo<TViewModel>(source);

				var result = destination.FirstOrDefault();

				return result;
			});

			return postTask;
		}

		public Task<Post> GetPostByPostName(string postTitle)
		{
			var postTask = Task.Run(() =>
			{
				var post = this.postsRepository.All().Where(p => p.Title == postTitle).FirstOrDefault();

				return post;
			});

			return postTask;
		}

		public Task<IEnumerable<TViewModel>> GetPostsByUsernameAsync<TViewModel>(
			UnprofessionalsAppUser currentUser)
		{
			var postTask = Task.Run(() =>
			{
				var source = this.postsRepository.All()
				.Where(p => !p.IsDeleted && p.UserId == currentUser.Id);
				//.To<TViewModel>()
				//.FirstOrDefault()

				var destination = this.mapper.ProjectTo<TViewModel>(source);

				var result = destination as IEnumerable<TViewModel>;

				return result;
			});

			return postTask;
		}
	}
}
