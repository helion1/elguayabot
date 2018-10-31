
using ElGuayaBot.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ElGuayaBot.Api.WebApi.Controllers
{
    [ApiController]
    public class BroadcastController: Controller
    {
        private readonly IBroadcastService _broadcastService;

        public BroadcastController(IBroadcastService broadcastService)
        {
            _broadcastService = broadcastService;
        }

        public ActionResult Communicate([FromBody] string message)
        {
            _broadcastService.CommunicateToAll(message);
            //TODO
            return Ok();
        }
    }
}