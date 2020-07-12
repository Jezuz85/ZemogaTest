using System.Collections.Generic;
using System.Threading.Tasks;

namespace Editor.Domain.Services
{
    public interface IEditorService
    {
        Task<bool> DeletePost(Editor.Domain.Dto.PostDeleteRequest post);

        Task<IEnumerable<Editor.Domain.Entities.Post>> GetPendingPosts();

        Task<bool> AproveRejectPost(Editor.Domain.Dto.PostRequest post);
    }
}