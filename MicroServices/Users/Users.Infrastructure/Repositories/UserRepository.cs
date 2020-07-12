using System;
using System.Linq;
using System.Threading.Tasks;
using Users.Domain.Dto;
using Users.Domain.Repositories;

namespace Users.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        /// <summary>
        /// Class constructor
        /// </summary>
        public UserRepository(UserContext context)
        {
            _context = context;
        }

        /// <summary>
        /// method that stores a comment for an approved post
        /// </summary>
        public async Task<bool> SaveComment(CommentSaveRequest comment)
        {
            try
            {
                var postToUpdate = _context.Post.FirstOrDefault(x => x.id == comment.id_post && x.state == "Aprove");

                if (postToUpdate != null)
                {
                    Domain.Entities.Comment newComment = new Domain.Entities.Comment
                    {
                        body = comment.body,
                        id_post = comment.id_post
                    };

                    _context.Comment.Add(newComment);

                    var save = await _context.SaveChangesAsync();

                    if (save > 0)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}