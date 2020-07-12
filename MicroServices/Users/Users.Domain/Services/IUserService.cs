using System.Threading.Tasks;
using Users.Domain.Dto;

namespace Users.Domain.Services
{
    /// <summary>
    /// service user interface
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Method that saves a user in the database
        /// </summary>
        Task<bool> SaveComment(CommentSaveRequest user);
    }
}