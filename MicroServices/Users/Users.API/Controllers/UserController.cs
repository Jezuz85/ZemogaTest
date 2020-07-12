using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Linq;
using System.Threading.Tasks;
using Users.API.Dto;
using Users.API.Facade.Interfaces;

namespace Users.API.Controllers
{
    /// <summary>
    /// Controller that handles users
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserFacade _facade;
        private Logger log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Class constructor
        /// </summary>
        public UserController(IUserFacade facade)
        {
            _facade = facade;
        }

        /// <summary>
        /// method that stores a comment for an approved post
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> SaveComment([FromBody] CommentSaveRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var message = ModelState.ToDictionary(d => d.Key, d => d.Value.Errors.Select(e => e.ErrorMessage).ToList());
                    return BadRequest(message);
                }

                var result = await _facade.SaveComment(request);

                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(new Exception(), ex.Message);
            }
            return null;
        }
    }
}