using System.Collections.Generic;
using System.Threading.Tasks;

namespace Editor.Domain.Repositories
{
    public interface IEditorRepository
    {
        /// <summary>
        /// Method that removes a user from the database
        /// </summary>
        Task<bool> DeletePost(Editor.Domain.Dto.PostDeleteRequest post);

        /// <summary>
        /// Method that get a user from the database
        /// </summary>
        Task<IEnumerable<Editor.Domain.Entities.Post>> GetPendingPosts();

        /// <summary>
        /// Method that update a user in the database
        /// </summary>
        Task<bool> AproveRejectPost(Editor.Domain.Dto.PostRequest post);
    }
}