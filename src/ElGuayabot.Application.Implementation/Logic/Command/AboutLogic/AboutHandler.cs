using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Contract.Client;
using ElGuayabot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types.Enums;

namespace ElGuayabot.Application.Implementation.Logic.Command.AboutLogic
{
    public class AboutHandler : AbstractHandler<AboutRequest>
    {
        public AboutHandler(IBotClient bot, ILogger<AbstractHandler<AboutRequest>> logger) : base(bot, logger)
        {
        }

        public override async Task<Unit> Handle(AboutRequest request, CancellationToken cancellationToken)
        {
            var message = request.Message;
            
            var aboutText = "<b>ElGuayaBot</b>, made with humor and code by [Lucas](https://github.com/elementh) and [Daniel](https://github.com/Zabrios) for our friend [Jose](https://github.com/ElGuayaba)";
            
            await Bot.SendTextMessageAsync(
                chatId: message.Chat.Id, 
                text: aboutText,
                parseMode: ParseMode.Html, 
                cancellationToken: cancellationToken);
            
            return Unit.Value;
        }
    }
}