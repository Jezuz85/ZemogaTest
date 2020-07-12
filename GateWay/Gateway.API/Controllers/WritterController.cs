namespace Gateway.API.Controllers
{
    using Facades.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using NLog;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Controller that handles writter
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class WritterController : ControllerBase
    {
        private readonly ISystemFacade _facade;
        private readonly IConfiguration _configuration;
        private Logger log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Class constructor
        /// </summary>
        public WritterController(ISystemFacade facade, IConfiguration configuration)
        {
            _facade = facade;
            _configuration = configuration;
        }

        /// <summary>
        /// Method that creates a post
        /// </summary>
        [HttpPost("[action]")]
        [Authorize]
        public async Task<IActionResult> CreatePost([FromBody] Gateway.API.Dto.CreatePostRequest request)
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