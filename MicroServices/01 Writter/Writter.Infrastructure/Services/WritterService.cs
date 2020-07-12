using System;
using System.Threading.Tasks;
using Writter.Domain.Dto;
using Writter.Domain.Repositories;
using Writter.Domain.Services;

namespace Writter.Infrastructure.Services
{
    public class WritterService : IWritterService
    {
        private readonly IWritterRepository _repository;

        /// <summary>
        /// Class constructor
        /// </summary>
        public WritterService(IWritterRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Method that validates a user's username and password
        /// </summary>
        public async Task<Writter.Domain.Entities.User> AutenticateUser(Writter.Domain.Dto.WritterLoginRequest user)
        {
            var users = await _repository.AutenticateUser(user);

            if (users == null)
            {
                throw new Exception("credenciales incorrectas");
            }

            return users;
        }

        public async Task<bool> CreatePost(CreatePostRequest post)
        {
            try
            {
                var result = await _repository.CreatePost(post);

                if (!result)
                {
                    throw new Exception("No se pudo crear el post");
                }
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}