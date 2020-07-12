using System.Threading.Tasks;
using Users.API.Dto;

namespace Users.API.Facade.Interfaces
{
    /// <summary>
    /// facade user interface
    /// </summary>
    public interface IUserFacade
    {
        /// <summary>
        /// method that stores a comment for an approved post
        /// </summary>
        Task<bool> SaveComment(CommentSaveRequest comment);
    }
}