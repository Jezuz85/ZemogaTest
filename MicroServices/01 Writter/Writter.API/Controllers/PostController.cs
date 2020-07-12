using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Linq;
using System.Threading.Tasks;
using Writter.API.Facade.Interfaces;

namespace Writter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IWritterFacade _facade;
        private Logger log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Class constructor
        /// </summary>
        public PostController(IWritterFacade facade)
        {
            _facade = facade;
        }

        /// <summary>
        /// Method that creates a post
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] Writter.API.Dto.CreatePostRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var message = ModelState.ToDictionary(d => d.Key, d => d.Value.Errors.Select(e => e.ErrorMessage).ToList());
                    return BadRequest(message);
                }

                var result = await _facade.CreatePost(request);

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