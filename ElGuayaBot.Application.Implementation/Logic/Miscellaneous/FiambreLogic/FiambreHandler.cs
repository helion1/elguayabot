using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Application.Implementation.Logic.Miscellaneous.FiambreLogic
{
    public class FiambreHandler : AbstractHandler<FiambreRequest>
    {
        public FiambreHandler(IBotClient bot, ILogger<AbstractHandler<FiambreRequest>> logger) : base(bot, logger)
        {
        }

        public override async Task<Unit> Handle(FiambreRequest request, CancellationToken cancellationToken)
        {
            var message = request.Message;
            
            await Bot.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "pues aquí hay fiambre",
                replyToMessageId: message.MessageId,
                cancellationToken: cancellationToken);
            
            return Unit.Value;
        }
    }
}