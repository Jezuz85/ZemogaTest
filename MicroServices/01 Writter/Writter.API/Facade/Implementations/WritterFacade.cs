using AutoMapper;
using System;
using System.Threading.Tasks;
using Writter.API.Facade.Interfaces;
using Writter.Domain.Services;

namespace Writter.API.Facade.Implementations
{
    public class WritterFacade : IWritterFacade
    {
        private readonly IMapper _mapper;
        private readonly IWritterService _service;

        /// <summary>
        /// Class constructor
        /// </summary>
        public WritterFacade(IWritterService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        public async Task<Writter.API.Dto.User> AutenticateUser(Writter.API.Dto.WritterLoginRequest user)
        {
            try
            {
                var newUser = _mapper.Map<Writter.Domain.Dto.WritterLoginRequest>(user);

                var response = _mapper.Map<Writter.API.Dto.User>(await _service.AutenticateUser(newUser));

                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Method that creates a post
        /// </summary>
        public async Task<bool> CreatePost(Writter.API.Dto.CreatePostRequest post)
        {
            try
            {
                var newPost = _mapper.Map<Writter.Domain.Dto.CreatePostRequest>(post);

                var response = await _service.CreatePost(newPost);

                return response;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}