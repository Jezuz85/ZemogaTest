using System.Threading.Tasks;
using Users.Domain.Dto;

namespace Users.Domain.Repositories
{
    /// <summary>
    /// repository user interface
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Method that saves a user in the database
        /// </summary>
        Task<bool> SaveComment(CommentSaveRequest user);
    }
}