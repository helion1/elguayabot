using System;
using ElGuayaBot.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Api.WebApi.Controllers
{
    [ApiController]
    public class BroadcastController: Controller
    {
        private readonly IBroadcastService _broadcastService;

        private readonly ILogger<BroadcastController> _logger;

        public BroadcastController(IBroadcastService broadcastService, ILogger<BroadcastController> logger)
        {
            _broadcastService = broadcastService ?? throw new ArgumentNullException(nameof(broadcastService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public ActionResult Communicate([FromBody] string message)
        {
            _logger.LogInformation($"Trying to broadcast the message: {message}");
            _broadcastService.CommunicateToAll(message);
            //TODO
            return Ok();
        }
    }
}