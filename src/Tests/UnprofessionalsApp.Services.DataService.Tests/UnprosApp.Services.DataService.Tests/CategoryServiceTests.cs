using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using UnprofessionalsApp.Common;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.DataServices.Contracts;
using UnprofessionalsApp.DataServices;
using UnprofessionalsApp.ViewInputModels.ViewModels.Categories;
using AutoMapper;
using UnprofessionalsApp.Mapping.Profiles.InputModels.Categoires;
using UnprofessionalsApp.Mapping.Profiles.Categories;

namespace UnprosApp.Services.DataService.Tests
{
	[TestFixture]
	public class CategoryServiceTests
	{
		private const int FirstCategory = 1;

		private readonly PostByCategoryViewModel testByCategoryViewModel 
			= new PostByCategoryViewModel{
						Id = 1,
						Title ="Pesho",
						ImageUrl = "nqma",
						Description = "nqma",
						IsDeleted = false,
						DateOfCreation = "10/10/2000",
						UserId = 1,
						Username = "nqma"
					};

		private Mock<IRepository<Category>> categoryRepository;

		[OneTimeSetUp]
		public void InitializeMapper()
		{
			Mapper.Initialize(opts =>
			{
				opts.AddProfile<CreateCategoryProfile>();
				opts.AddProfile<PostByCategoryProfile>();
			});
		}

		[SetUp]
		public void Setup()
		{
			this.categoryRepository = new Mock<IRepository<Category>>();
			categoryRepository.Setup(c => c.All()).Returns(new List<Category>
			{
				new Category() { Id = 1, Name = "test", Posts = new List<Post>
				{
					new Post
					{
						Id = 1,
						Title = "Pesho",
						Description = "nqma",
						Image = new Image{ Url = "nqma"},
						IsDeleted = false,
						DateOfCreation = new DateTime(2000,10,10),
						UserId = 1,
						User = new UnprofessionalsAppUser { Id =1, UserName = "nqma", Email = "nqma@nqma.nqma"},
						CategoryId = 1
						
					}
				}},
				new Category() { Id = 2, Name = "test1"},
				new Category() { Id = 3, Name = "test2"},
			}.AsQueryable());
		}

		[Test]
		public void GetAllCategories_Return_Categories()
		{
			var service = new CategoriesService(this.categoryRepository.Object, null);

			var actual = service.GetCount();

			var expected = 3;

			Assert.AreEqual(expected, actual);
			categoryRepository.Verify(x => x.All(), Times.Once);
		}

		[Test]
		public async Task GetAllCategories_ShouldReturn_CollectionOfViewModels()
		{
			var mapper = new Mapper(Mapper.Configuration);
			var service = new CategoriesService(categoryRepository.Object, mapper);

			var categoryService = new Mock<ICategoriesService>();

			categoryService.Setup(c => c.GetAllCategories()).Returns(
			Task.Run(() =>
			{
				var viewModels = new List<CategorySearchViewModel>
				{
					new CategorySearchViewModel() { Id = 1, Name = "test" },
					new CategorySearchViewModel() { Id = 2, Name = "test1"},
					new CategorySearchViewModel() { Id = 3, Name = "test2"}
				};

				return viewModels.AsEnumerable();
			}));

			var expected = (await categoryService.Object.GetAllCategories()).Select(e => e.Id).ToList();

			var actual = (await service.GetAllCategories()).Select(a => a.Id).ToList();

			Assert.That(actual, Is.EquivalentTo(expected));
			categoryRepository.Verify(x => x.All(), Times.Once);
		}

		[Test]
		public async Task GetLetters_ShouldReturn_ExpectedLetter()
		{
			var mapper = new Mapper(Mapper.Configuration);
			var service = new CategoriesService(this.categoryRepository.Object, mapper);

			var categoryService = new Mock<ICategoriesService>();

			categoryService.Setup(c => c.GetExistingStartingLettersForAllCategories()).Returns(
			Task.Run(() =>
			{
				var result = "T";

				return result;
			}));

			var expected = await categoryService.Object.GetExistingStartingLettersForAllCategories();

			var actual = await service.GetExistingStartingLettersForAllCategories();

			Assert.AreEqual(expected, actual);
			categoryRepository.Verify(x => x.All(), Times.Once);
		}

		[Test]
		public async Task PostByCategory_ShouldReturn_IEnumerableOfPostsViewModels()
		{
			var mapper = new Mapper(Mapper.Configuration);
			var service = new CategoriesService(this.categoryRepository.Object, mapper);

			var categoryService = new Mock<ICategoriesService>();

			categoryService.Setup(c => c.GetAllRealtedPosts(1))
			.Returns(Task.Run(() =>
			{
				var result = new List<PostByCategoryViewModel>
				{
					this.testByCategoryViewModel
				};

				return result.AsEnumerable();
			}));

			var actual = (await service.GetAllRealtedPosts(FirstCategory)).FirstOrDefault();

			var expected = (await categoryService.Object.GetAllRealtedPosts(FirstCategory))
				.FirstOrDefault();


			Assert.AreEqual(expected.DateOfCreation, actual.DateOfCreation);
			Assert.AreEqual(expected.Description, actual.Description);
			Assert.AreEqual(expected.Id, actual.Id);
			Assert.AreEqual(expected.ImageUrl, actual.ImageUrl);
			Assert.AreEqual(expected.UserId, actual.UserId);
			Assert.AreEqual(expected.Username, actual.Username);
			Assert.AreEqual(expected.Title, actual.Title);
			categoryRepository.Verify(x => x.All(), Times.Once);
		}

		[Test]
		public async Task PostByCategory_ShouldReturnNull()
		{
			var mapper = new Mapper(Mapper.Configuration);
			var service = new CategoriesService(this.categoryRepository.Object, mapper);

			object expected = null;

			var actual = (await service.GetAllRealtedPosts(0)).FirstOrDefault();

			Assert.AreEqual(expected, actual);
			categoryRepository.Verify(x => x.All(), Times.Once);
		}

		/*
		 * Task<string> GetExistingStartingLettersForAllCategories(); // Wat
		 * 
		 * Task<IEnumerable<PostByCategoryViewModel>> GetAllRealtedPosts(int categoryId);
		 * Task<bool> AreThereAnyPostsWithCategory(int categoryId);
		 * Task<int> CreateCategory(CreateCategoryInputModel inputModel);
		 * Task<Category> FindByName(string name);
		 * 
		 */
	}
}
