using System.Threading.Tasks;

namespace Gateway.Domain.Services
{
    /// <summary>
    /// facade user interface
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Method that saves a comment in the database
        /// </summary>
        Task<bool> SaveComment(Gateway.Domain.Dto.CommentSaveRequest comment);
    }
}