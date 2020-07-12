namespace Gateway.API.Controllers
{
    using Dto;
    using Facades.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using NLog;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Controller that handles users
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ISystemFacade _facade;
        private readonly IConfiguration _configuration;
        private Logger log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Class constructor
        /// </summary>
        public UsersController(ISystemFacade facade, IConfiguration configuration)
        {
            _facade = facade;
            _configuration = configuration;
        }

        /// <summary>
        /// Method that validates a user's username and password
        /// </summary>
        [HttpPost("[action]")]
        [AllowAnonymous]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            try
            {
                var _userInfo = await _facade.AutenticateUser(request);

                if (_userInfo != null)
                {
                    return Ok(new { token = GenerarTokenJWT(_userInfo) });
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                log.Error(new Exception(), ex.Message);
            }

            return null;
        }

        /// <summary>
        /// method that stores a comment for an approved post
        /// </summary>
        [HttpPost("[action]")]
        [EnableCors("AllowOrigin")]
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

        /// <summary>
        /// Method that generates a token for a user
        /// </summary>
        private string GenerarTokenJWT(User user)
        {
            try
            {
                // CREAMOS EL HEADER //
                var _symmetricSecurityKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_configuration["JWT:ClaveSecreta"])
                    );
                var _signingCredentials = new SigningCredentials(
                        _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                    );
                var _Header = new JwtHeader(_signingCredentials);

                // CREAMOS LOS CLAIMS //
                var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("user_login", user.user_login),
                new Claim("id", user.id.ToString()),
                new Claim("isEditor", user.isEditor.ToString())
            };

                // CREAMOS EL PAYLOAD //
                var _Payload = new JwtPayload(
                        issuer: _configuration["JWT:Issuer"],
                        audience: _configuration["JWT:Audience"],
                        claims: _Claims,
                        notBefore: DateTime.UtcNow,
                        // Exipra a la 24 horas.
                        expires: DateTime.UtcNow.AddHours(24)
                    );

                // GENERAMOS EL TOKEN //
                var _Token = new JwtSecurityToken(
                        _Header,
                        _Payload
                    );

                return new JwtSecurityTokenHandler().WriteToken(_Token);
            }
            catch (Exception ex)
            {
                log.Error(new Exception(), ex.Message);
            }
            return string.Empty;
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