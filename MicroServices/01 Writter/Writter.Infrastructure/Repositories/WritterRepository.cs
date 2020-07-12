using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Writter.Domain.Dto;
using Writter.Domain.Repositories;

namespace Writter.Infrastructure.Repositories
{
    public class WritterRepository : IWritterRepository
    {
        private readonly WritterContext _context;

        /// <summary>
        /// Class constructor
        /// </summary>
        public WritterRepository(WritterContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method that validates a user's username and password
        /// </summary>
        public async Task<Writter.Domain.Entities.User> AutenticateUser(Writter.Domain.Dto.WritterLoginRequest user)
        {
            try
            {
                var LoginUsers = await _context.User.
                    FirstOrDefaultAsync(x => x.user_login == user.user_login
                        && user.password_login == user.password_login);
                return LoginUsers;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                _context.Dispose();
            }
        }

        /// <summary>
        /// Method that creates a post
        /// </summary>
        public async Task<bool> CreatePost(CreatePostRequest post)
        {
            try
            {
                Writter.Domain.Entities.Post newPost = new Writter.Domain.Entities.Post
                {
                    datePublish = DateTime.Now,
                    body = post.body,
                    state = "Pending",
                };

                _context.Post.Add(newPost);

                var save = _context.SaveChanges();

                if (save > 0)
                {
                    Writter.Domain.Entities.Post_User newPost_User = new Writter.Domain.Entities.Post_User
                    {
                        id_writter = post.idWritter,
                        id_post = newPost.id
                    };

                    _context.Post_User.Add(newPost_User);
                    save = _context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}