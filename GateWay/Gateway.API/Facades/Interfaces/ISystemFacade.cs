using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gateway.API.Facades.Interfaces
{
    /// <summary>
    /// facade interface
    /// </summary>
    public interface ISystemFacade
    {
        /// <summary>
        /// Method that approves or rejects a post
        /// </summary>
        Task<bool> AproveRejectPost(Gateway.API.Dto.PostRequest post);

        /// <summary>
        /// Method that validates a user's username and password
        /// </summary>
        Task<Gateway.API.Dto.User> AutenticateUser(Gateway.API.Dto.UserLoginRequest user);

        /// <summary>
        /// Method that creates a post
        /// </summary>
        Task<bool> CreatePost(Gateway.API.Dto.CreatePostRequest post);

        /// <summary>
        /// Method that deletes a post
        /// </summary>
        Task<bool> DeletePost(Gateway.API.Dto.PostDeleteRequest post);

        /// <summary>
        /// Method that obtains the post pending approval or rejection
        /// </summary>
        Task<IEnumerable<Gateway.API.Dto.Post>> GetPendingPosts();

        /// <summary>
        /// Method that saves a comment in the database
        /// </summary>
        Task<bool> SaveComment(Gateway.API.Dto.CommentSaveRequest comment);
    }
}