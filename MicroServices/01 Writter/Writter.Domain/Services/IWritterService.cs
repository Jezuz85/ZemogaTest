using System.Threading.Tasks;

namespace Writter.Domain.Services
{
    /// <summary>
    /// service user interface
    /// </summary>
    public interface IWritterService
    {
        /// <summary>
        /// Method that validates a user's username and password
        /// </summary>
        Task<Writter.Domain.Entities.User> AutenticateUser(Writter.Domain.Dto.WritterLoginRequest user);

        /// <summary>
        /// Method that creates a post
        /// </summary>
        Task<bool> CreatePost(Writter.Domain.Dto.CreatePostRequest post);
    }
}