using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Contract.Client;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types.Enums;

namespace ElGuayaBot.Application.Implementation.Logic.Miscellaneous.AlFinalMeMosqueoLogic
{
    public class AlFinalMeMosqueoHandler : AbstractHandler<AlFinalMeMosqueoRequest>
    {
        public AlFinalMeMosqueoHandler(IBotClient bot, ILogger<AbstractHandler<AlFinalMeMosqueoRequest>> logger) : base(bot, logger)
        {
        }

        public override async Task<Unit> Handle(AlFinalMeMosqueoRequest request, CancellationToken cancellationToken)
        {
            var message = request.Message;
            
            var responses = new List<string>
            {
                "At the end I will fly",
                "Get the fuck out, bitch",
                "I'm gonna get mad",
                "At late I'll fly",
                "Finally, I turn into a fly",
                "You are pissing me off",
                "At the end I will get flyed",
                "In the finish, I give tollinas",
                "In the end, I become a fly",
                "At least I'm being angry",
                "To the end I fly myself",
                "At the end I fucking shit",
                "To him ending my flyize",
                "At the end I'm flied, of nothing",
                "In the end I'll be a fly",
                "At the end, I fly myself",
                "I'm getting fly",
                "At last, I fly it",
                "At last, I became The Fly",
                "A hug strong",
                "To the end I enfly myself",
                "I will turn myself into a fly",
                "I believe I can fly",
                "I would end up pissing off",
                "I believe I can fly",
                "At the end, I will fly myself on",
                "In di end aim flaiin"
            };
            
            var rnd = new Random();
            
            var r = rnd.Next(responses.Count);
            
            var response = $"<i>{responses[r]}</i>";
            
            await Bot.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: response,
                parseMode: ParseMode.Html,
                cancellationToken: cancellationToken);
            
            return Unit.Value;
        }
    }
}