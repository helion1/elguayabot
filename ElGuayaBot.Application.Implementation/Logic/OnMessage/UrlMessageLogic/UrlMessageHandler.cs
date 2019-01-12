using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Application.Implementation.Logic.OnMessage.UrlMessageLogic
{
    public class UrlMessageHandler : AbstractHandler<UrlMessageRequest>
    {
        public UrlMessageHandler(IBotClient bot, ILogger<AbstractHandler<UrlMessageRequest>> logger) : base(bot, logger)
        {
        }

        public override async Task<Unit> Handle(UrlMessageRequest request, CancellationToken cancellationToken)
        {
            //URL
            //                if (message.Text.ToLower().Contains(".gif") && message.Text.ToLower().StartsWith("https://"))
//                {
//                    _tenorGifFlow.Initiate(message);
//                }
            throw new System.NotImplementedException();
        }
    }
}