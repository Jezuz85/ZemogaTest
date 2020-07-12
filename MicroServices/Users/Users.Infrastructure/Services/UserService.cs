using System;
using System.Threading.Tasks;
using Users.Domain.Dto;
using Users.Domain.Repositories;
using Users.Domain.Services;

namespace Users.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        /// <summary>
        /// Class constructor
        /// </summary>
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Method that saves a user in the database
        /// </summary>
        public async Task<bool> SaveComment(CommentSaveRequest user)
        {
            try
            {
                var result = await _repository.SaveComment(user);

                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}