using AutoMapper;
using System;
using System.Threading.Tasks;
using Users.API.Dto;
using Users.API.Facade.Interfaces;
using Users.Domain.Services;

namespace Users.API.Facade.Implementations
{
    public class UserFacade : IUserFacade
    {
        private readonly IMapper _mapper;
        private readonly IUserService _service;

        /// <summary>
        /// Class constructor
        /// </summary>
        public UserFacade(IUserService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        /// <summary>
        /// method that stores a comment for an approved post
        /// </summary>
        public async Task<bool> SaveComment(CommentSaveRequest user)
        {
            try
            {
                var newUser = _mapper.Map<Domain.Dto.CommentSaveRequest>(user);

                var response = await _service.SaveComment(newUser);

                return response;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}