using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Contract.Client;
using ElGuayabot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types.Enums;

namespace ElGuayabot.Application.Implementation.Logic.Miscellaneous.ButGoldLogic
{
    public class ButGoldHandler : AbstractHandler<ButGoldRequest>
    {
        public ButGoldHandler(IBotClient bot, ILogger<AbstractHandler<ButGoldRequest>> logger) : base(bot, logger)
        {
        }

        public override async Task<Unit> Handle(ButGoldRequest request, CancellationToken cancellationToken)
        {
            var message = request.Message;
            
            await Bot.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "but (<b>g</b>)old",
                parseMode: ParseMode.Html,
                cancellationToken: cancellationToken);
            
            return Unit.Value;
        }
    }
}