using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Linq;
using System.Threading.Tasks;
using Writter.API.Facade.Interfaces;

namespace Writter.API.Controllers
{
    /// <summary>
    /// Controller that handles users
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class WritterController : ControllerBase
    {
        private readonly IWritterFacade _facade;
        private Logger log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Class constructor
        /// </summary>
        public WritterController(IWritterFacade facade)
        {
            _facade = facade;
        }

        /// <summary>
        /// Method that validates a user's username and password
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AutenticateUser([FromBody] Writter.API.Dto.WritterLoginRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var message = ModelState.ToDictionary(d => d.Key, d => d.Value.Errors.Select(e => e.ErrorMessage).ToList());
                    return BadRequest(message);
                }

                var result = await _facade.AutenticateUser(request);

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