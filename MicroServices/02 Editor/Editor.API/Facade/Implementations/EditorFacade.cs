using AutoMapper;
using Editor.API.Dto;
using Editor.API.Facade.Interfaces;
using Editor.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Editor.API.Facade.Implementations
{
    public class EditorFacade : IEditorFacade
    {
        private readonly IMapper _mapper;
        private readonly IEditorService _service;

        /// <summary>
        /// Class constructor
        /// </summary>
        public EditorFacade(IEditorService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        /// <summary>
        /// Method that approves or rejects a post
        /// </summary>
        public async Task<bool> AproveRejectPost(PostRequest post)
        {
            try
            {
                var newPost = _mapper.Map<Domain.Dto.PostRequest>(post);

                var response = await _service.AproveRejectPost(newPost);

                return response;
            }
            catch (Exception ex)
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
                var newPost = _mapper.Map<Domain.Dto.PostDeleteRequest>(post);

                var response = await _service.DeletePost(newPost);

                return response;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Method that obtains the post pending approval or rejection
        /// </summary>
        public async Task<IEnumerable<Post>> GetPendingPosts()
        {
            try
            {
                var response = _mapper.Map<IEnumerable<Post>>(await _service.GetPendingPosts());
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}