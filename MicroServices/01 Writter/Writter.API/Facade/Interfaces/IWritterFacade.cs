using System.Threading.Tasks;

namespace Writter.API.Facade.Interfaces
{
    /// <summary>
    /// facade writter interface
    /// </summary>
    public interface IWritterFacade
    {
        /// <summary>
        /// Method that validates a user's username and password
        /// </summary>
        Task<Writter.API.Dto.User> AutenticateUser(Writter.API.Dto.WritterLoginRequest user);

        /// <summary>
        /// Method that creates a post
        /// </summary>
        Task<bool> CreatePost(Writter.API.Dto.CreatePostRequest post);
    }
}