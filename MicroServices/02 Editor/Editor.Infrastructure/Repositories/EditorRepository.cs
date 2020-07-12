using Editor.Domain.Dto;
using Editor.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Editor.Infrastructure.Repositories
{
    public class EditorRepository : IEditorRepository
    {
        private readonly EditorContext _context;

        /// <summary>
        /// Class constructor
        /// </summary>
        public EditorRepository(EditorContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method that approves or rejects a post
        /// </summary>
        public async Task<bool> AproveRejectPost(PostRequest post)
        {
            try
            {
                int idPost = Convert.ToInt32(post.id);
                int idEditor = Convert.ToInt32(post.id_Editor);
                var postToUpdate = _context.Post.FirstOrDefault(x => x.id == idPost && x.state == "Pending");

                if (postToUpdate != null)
                {
                    if (post.state)
                    {
                        postToUpdate.state = "Aprove";
                    }
                    else
                    {
                        postToUpdate.state = "Reject";
                    }

                    postToUpdate.datePublish = DateTime.Now;

                    _context.Post.Update(postToUpdate);

                    var result = await _context.SaveChangesAsync();

                    if (result > 0)
                    {
                        var postUserToUpdate = _context.Post_User.FirstOrDefault(x => x.id_post == idPost);
                        postUserToUpdate.id_editor = post.id_Editor;
                        await _context.SaveChangesAsync();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                _context.Dispose();
            }
        }

        /// <summary>
        /// Method that deletes a post
        /// </summary>
        public async Task<bool> DeletePost(PostDeleteRequest post)
        {
            try
            {
                int idPost = Convert.ToInt32(post.id);
                var postToRemove = _context.Post.FirstOrDefault(x => x.id == idPost);
                var Post_UserToRemove = _context.Post_User.FirstOrDefault(x => x.id_post == idPost);
                var CommentToRemove = _context.Comment.FirstOrDefault(x => x.id_post == idPost);

                if (postToRemove != null)
                {
                    _context.Post.Remove(postToRemove);
                    _context.Post_User.Remove(Post_UserToRemove);
                }
                if (CommentToRemove != null)
                {
                    _context.Comment.Remove(CommentToRemove);
                }

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                _context.Dispose();
            }
        }

        /// <summary>
        /// Method that obtains the post pending approval or rejection
        /// </summary>
        public async Task<IEnumerable<Editor.Domain.Entities.Post>> GetPendingPosts()
        {
            try
            {
                var ListPendingPost = await _context.Post.Where(x => x.state == "Pending").ToListAsync();
                return ListPendingPost;
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
    }
}