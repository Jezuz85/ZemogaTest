namespace Gateway.API.Facades.Implementations
{
    using AutoMapper;
    using Facades.Interfaces;
    using Gateway.Domain.Services;
    using NLog;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// class that manages the facade for the consumption of users' api
    /// </summary>
    public class SystemFacade : ISystemFacade
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IWritterService _writterService;
        private readonly IEditorService _editorService;
        private Logger log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Class constructor
        /// </summary>
        public SystemFacade(IUserService userService, IWritterService writterService,
            IEditorService editorService, IMapper mapper)
        {
            _userService = userService;
            _editorService = editorService;
            _writterService = writterService;
            _mapper = mapper;
        }

        /// <summary>
        /// Method that approves or rejects a post
        /// </summary>
        public async Task<bool> AproveRejectPost(Dto.PostRequest post)
        {
            try
            {
                var newUser = _mapper.Map<Domain.Dto.PostRequest>(post);
                var response = await _editorService.AproveRejectPost(newUser);

                return response;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Method that validates a user's username and password
        /// </summary>
        public async Task<Dto.User> AutenticateUser(Gateway.API.Dto.UserLoginRequest user)
        {
            try
            {
                var newUser = _mapper.Map<Gateway.Domain.Dto.UserLoginRequest>(user);

                Gateway.Domain.Dto.User response = await _writterService.AutenticateUser(newUser);

                var response2 = _mapper.Map<Gateway.API.Dto.User>(response);

                return response2;
            }
            catch (Exception ex)
            {
                log.Error(new Exception(), ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Method that creates a post
        /// </summary>
        public async Task<bool> CreatePost(Dto.CreatePostRequest post)
        {
            try
            {
                var newPost = _mapper.Map<Domain.Dto.CreatePostRequest>(post);

                var Response = await _writterService.CreatePost(newPost);

                return Response;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Method that deletes a post
        /// </summary>
        public async Task<bool> DeletePost(Dto.PostDeleteRequest post)
        {
            try
            {
                var newPost = _mapper.Map<Domain.Dto.PostDeleteRequest>(post);
                var response = await _editorService.DeletePost(newPost);

                return response;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Method that obtains the post pending approval or rejection
        /// </summary>
        public async Task<IEnumerable<Dto.Post>> GetPendingPosts()
        {
            try
            {
                IEnumerable<Domain.Dto.Post> response = await _editorService.GetPendingPosts();

                var response2 = _mapper.Map<IEnumerable<Gateway.API.Dto.Post>>(response);

                return response2;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// method that stores a comment for an approved post
        /// </summary>
        public async Task<bool> SaveComment(Dto.CommentSaveRequest comment)
        {
            try
            {
                var newPost = _mapper.Map<Domain.Dto.CommentSaveRequest>(comment);

                var Response = await _userService.SaveComment(newPost);

                return Response;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}