using Editor.API.Dto;
using Editor.API.Facade.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Editor.API.Controllers
{
    /// <summary>
    /// Controller that handles users
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EditorController : ControllerBase
    {
        private readonly IEditorFacade _facade;
        private Logger log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Class constructor
        /// </summary>
        public EditorController(IEditorFacade facade)
        {
            _facade = facade;
        }

        /// <summary>
        /// Method that deletes a post
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> DeletePost([FromBody] Editor.API.Dto.PostDeleteRequest request)
        {
            try
            {
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
        [HttpGet]
        public async Task<IActionResult> GetPendingPosts()
        {
            try
            {
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
        /// Method that approves or rejects a post
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> AproveRejectPost([FromBody] PostRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var message = ModelState.ToDictionary(d => d.Key, d => d.Value.Errors.Select(e => e.ErrorMessage).ToList());
                    return BadRequest(message);
                }

                var result = await _facade.AproveRejectPost(request);

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