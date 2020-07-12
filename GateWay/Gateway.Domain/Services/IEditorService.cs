using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gateway.Domain.Services
{
    public interface IEditorService
    {
        Task<bool> DeletePost(Gateway.Domain.Dto.PostDeleteRequest post);

        Task<IEnumerable<Gateway.Domain.Dto.Post>> GetPendingPosts();

        Task<bool> AproveRejectPost(Gateway.Domain.Dto.PostRequest post);
    }
}