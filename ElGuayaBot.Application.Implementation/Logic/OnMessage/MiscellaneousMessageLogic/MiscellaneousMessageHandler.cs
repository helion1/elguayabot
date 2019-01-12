using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;
using MihaZupan.TelegramBotClients;

namespace ElGuayaBot.Application.Implementation.Logic.OnMessage.MiscellaneousMessageLogic
{
    public class MiscellaneousMessageHandler : AbstractHandler<MiscellaneousMessageRequest>
    {
        public MiscellaneousMessageHandler(IBotClient bot, ILogger<AbstractHandler<MiscellaneousMessageRequest>> logger) : base(bot, logger)
        {
        }

        public override Task<Unit> Handle(MiscellaneousMessageRequest request, CancellationToken cancellationToken)
        {
            //                else
//                {
//                    if(message.Text.ToLower().Contains("puto guayaba"))
//                    {
//                        _putoGuayaba.Initiate(message);
//                    }
//                    else
//                    {
//                        _randomTextFlow.Initiate(message);
//                    }
//
            throw new System.NotImplementedException();
        }
    }
}