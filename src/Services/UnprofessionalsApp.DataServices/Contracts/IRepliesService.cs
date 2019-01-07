using System.Threading.Tasks;
using UnprofessionalsApp.ViewInputModels.InputModels.Replies;

namespace UnprofessionalsApp.DataServices.Contracts
{
	public interface IRepliesService
	{
		Task<int> CreateReply(CreateInputModel replyModel);
	}
}
