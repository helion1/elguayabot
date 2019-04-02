using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contract.Client;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Application.Implementation.Logic.Miscellaneous.ColdMeatLogic
{
    public class ColdMeatHandler : AbstractHandler<ColdMeatRequest>
    {
        public ColdMeatHandler(IBotClient bot, ILogger<AbstractHandler<ColdMeatRequest>> logger) : base(bot, logger)
        {
        }

        public override async Task<Unit> Handle(ColdMeatRequest request, CancellationToken cancellationToken)
        {
            var message = request.Message;
            
            await Bot.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "well here is cold meat",
                replyToMessageId: message.MessageId,
                cancellationToken: cancellationToken);
            
            return Unit.Value;
        }
    }
}