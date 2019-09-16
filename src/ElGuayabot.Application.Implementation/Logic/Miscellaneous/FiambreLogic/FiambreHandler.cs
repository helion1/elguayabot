using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Contract.Client;
using ElGuayabot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayabot.Application.Implementation.Logic.Miscellaneous.FiambreLogic
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