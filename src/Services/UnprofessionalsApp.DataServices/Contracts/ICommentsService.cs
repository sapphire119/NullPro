using System.Collections.Generic;
using System.Threading.Tasks;
using UnprofessionalsApp.Models;
using UnprofessionalsApp.ViewInputModels.InputModels.Comments;

namespace UnprofessionalsApp.DataServices.Contracts
{
	public interface ICommentsService
	{
		Task<int> CreateComment(CreateInputModel inputModel);

		Task<IEnumerable<TViewModel>> GetCommentsForCurrentUser<TViewModel>(UnprofessionalsAppUser currentUser);
	}
}
