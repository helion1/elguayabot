using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Contract.Client;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types.Enums;

namespace ElGuayaBot.Application.Implementation.Logic.Command.EchoLogic
{
    public class EchoHandler : AbstractHandler<EchoRequest>
    {
        public EchoHandler(IBotClient bot, ILogger<AbstractHandler<EchoRequest>> logger) : base(bot, logger)
        {
        }

        public override async Task<Unit> Handle(EchoRequest request, CancellationToken cancellationToken)
        {
            var message = request.Message;
            
            var restOfText = message.Text.Substring(message.Text.IndexOf(' ') + 1);

            if (restOfText != message.Text && restOfText.Trim() != "")
            {
                await Bot.SendTextMessageAsync(
                    chatId: message.Chat.Id, 
                    text: $"`{restOfText}`",
                    parseMode: ParseMode.Markdown, 
                    cancellationToken: cancellationToken);
            }

            return Unit.Value;
        }
    }
}