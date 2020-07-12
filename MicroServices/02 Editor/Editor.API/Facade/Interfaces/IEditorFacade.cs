using System.Collections.Generic;
using System.Threading.Tasks;

namespace Editor.API.Facade.Interfaces
{
    /// <summary>
    /// facade user interface
    /// </summary>
    public interface IEditorFacade
    {
        /// <summary>
        /// Method that deletes a post
        /// </summary>
        Task<bool> DeletePost(Editor.API.Dto.PostDeleteRequest post);

        /// <summary>
        /// Method that obtains the post pending approval or rejection
        /// </summary>
        Task<IEnumerable<Editor.API.Dto.Post>> GetPendingPosts();

        /// <summary>
        /// Method that approves or rejects a post
        /// </summary>
        Task<bool> AproveRejectPost(Editor.API.Dto.PostRequest post);
    }
}