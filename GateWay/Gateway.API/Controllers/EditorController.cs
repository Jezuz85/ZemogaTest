namespace Gateway.API.Controllers
{
    using Dto;
    using Facades.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using NLog;
    using System;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    /// <summary>
    /// Controller that handles editor
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EditorController : ControllerBase
    {
        private readonly ISystemFacade _facade;
        private Logger log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Class constructor
        /// </summary>
        public EditorController(ISystemFacade facade)
        {
            _facade = facade;
        }

        /// <summary>
        /// Method that approves or rejects a post
        /// </summary>
        [HttpPut("[action]")]
        [Authorize]
        public async Task<IActionResult> AproveRejectPost([FromBody] PostRequest request)
        {
            try
            {
                if (!ValidateRole())
                {
                    return Unauthorized();
                }

                if (!ModelState.IsValid)
                {
                    var message = ModelState.ToDictionary(d => d.Key, d => d.Value.Errors.Select(e => e.ErrorMessage).ToList());
                    return BadRequest(message);
                }

                request.id_Editor = GetIdEditor();
                var result = await _facade.AproveRejectPost(request);

                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(new Exception(), ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Method that deletes a post
        /// </summary>
        [HttpDelete("[action]")]
        [Authorize]
        public async Task<IActionResult> DeletePost([FromBody] Gateway.API.Dto.PostDeleteRequest request)
        {
            try
            {
                if (!ValidateRole())
                {
                    return Unauthorized();
                }

                if (!ModelState.IsValid)
                {
                    var message = ModelState.ToDictionary(d => d.Key, d => d.Value.Errors.Select(e => e.ErrorMessage).ToList());
                    return BadRequest(message);
                }

                var result = await _facade.DeletePost(request);

                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(new Exception(), ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Method that obtains the post pending approval or rejection
        /// </summary>
        [HttpGet("[action]")]
        [Authorize]
        public async Task<IActionResult> GetPendingPosts()
        {
            try
            {
                if (!ValidateRole())
                {
                    return Unauthorized();
                }

                var result = await _facade.GetPendingPosts();
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(new Exception(), ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Method that obtains the id of a person logged in
        /// </summary>
        private int GetIdEditor()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int miclaim = 0;

                if (identity != null)
                {
                    miclaim = Convert.ToInt32(identity.FindFirst("id").Value);
                }

                return miclaim;
            }
            catch (Exception ex)
            {
                log.Error(new Exception(), ex.Message);
            }
            return 0;
        }

        /// <summary>
        /// Method that validates if a user is an administrator
        /// </summary>
        private bool ValidateRole()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                bool miclaim = false;

                if (identity != null)
                {
                    miclaim = Convert.ToBoolean(identity.FindFirst("isEditor").Value);
                }

                return miclaim;
            }
            catch (Exception ex)
            {
                log.Error(new Exception(), ex.Message);
            }
            return false;
        }
    }
}