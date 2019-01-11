using System;
using ElGuayaBot.Application.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Api.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class BroadcastController: ControllerBase
    {
        private readonly IBroadcastService _broadcastService;

        private readonly ILogger<BroadcastController> _logger;

        public BroadcastController(IBroadcastService broadcastService, ILogger<BroadcastController> logger)
        {
            _broadcastService = broadcastService ?? throw new ArgumentNullException(nameof(broadcastService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

//        [HttpPost]
//        [Authorize(Policy = "Administrator")]
//        [Route("login")]
//        public ActionResult Communicate([FromBody] string message)
//        {
//            _logger.LogInformation($"Trying to broadcast the message: {message}");
//            _broadcastService.CommunicateToAll(message);
//            //TODO
//            return Ok();
//        }
    }
}