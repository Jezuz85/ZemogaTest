using System.Threading.Tasks;

namespace Gateway.Domain.Services
{
    public interface IWritterService
    {
        /// <summary>
        /// Method that validates a user's username and password
        /// </summary>
        Task<Gateway.Domain.Dto.User> AutenticateUser(Gateway.Domain.Dto.UserLoginRequest user);

        Task<bool> CreatePost(Gateway.Domain.Dto.CreatePostRequest post);
    }
}