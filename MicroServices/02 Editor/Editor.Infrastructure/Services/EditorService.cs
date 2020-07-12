using Editor.Domain.Dto;
using Editor.Domain.Repositories;
using Editor.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Editor.Infrastructure.Services
{
    public class EditorService : IEditorService
    {
        private readonly IEditorRepository _repository;

        /// <summary>
        /// Class constructor
        /// </summary>
        public EditorService(IEditorRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Method that approves or rejects a post
        /// </summary>
        public async Task<bool> AproveRejectPost(PostRequest post)
        {
            try
            {
                var result = await _repository.AproveRejectPost(post);

                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Method that deletes a post
        /// </summary>
        public async Task<bool> DeletePost(PostDeleteRequest post)
        {
            try
            {
                var result = await _repository.DeletePost(post);

                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Method that obtains the post pending approval or rejection
        /// </summary>
        public async Task<IEnumerable<Editor.Domain.Entities.Post>> GetPendingPosts()
        {
            try
            {
                var PendingPosts = await _repository.GetPendingPosts();

                if (PendingPosts == null)
                {
                    throw new Exception("No existen posts");
                }

                return PendingPosts;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}