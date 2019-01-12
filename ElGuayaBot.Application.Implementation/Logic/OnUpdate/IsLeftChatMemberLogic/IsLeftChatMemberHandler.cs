using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Application.Implementation.Logic.OnUpdate.IsLeftChatMemberLogic
{
    public class IsLeftChatMemberHandler : AbstractHandler<IsLeftChatMemberRequest>
    {
        public IsLeftChatMemberHandler(IBotClient bot, ILogger<AbstractHandler<IsLeftChatMemberRequest>> logger) : base(bot, logger)
        {
        }

        public override async Task<Unit> Handle(IsLeftChatMemberRequest request, CancellationToken cancellationToken)
        {
            var update = request.Update;
            
            var message = update.Message;
            
            var user = message.LeftChatMember;

            if (!user.IsBot)
            {
                await Bot.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: $"@{user.Username} murió combatiendo el imperialismo. ",
                    replyToMessageId: message.MessageId, 
                    cancellationToken: cancellationToken);
            }
            
            return Unit.Value;
        }
    }
}