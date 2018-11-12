using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ElGuayaBot.Api.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace ElGuayaBot.Api.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        protected readonly IConfiguration Configuration;

        private readonly ILogger<AuthController> _logger;

        public AuthController(IConfiguration configuration, ILogger<AuthController> logger)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public IActionResult RequestToken([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                //log
                return BadRequest(ModelState);
            }
            
            if (request.Username != Configuration["Admin:Username"] || request.Password != Configuration["Admin:Password"])
            {
                return NotFound("User not found in the app database");
            }
            else
            {
                return Ok("adsad");
            }
        }
    }
}