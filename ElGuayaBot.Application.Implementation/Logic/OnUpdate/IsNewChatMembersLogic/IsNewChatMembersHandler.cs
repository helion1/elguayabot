using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Application.Implementation.Logic.OnUpdate.IsNewChatMembersLogic
{
    public class IsNewChatMembersHandler : AbstractHandler<IsNewChatMembersRequest>
    {
        public IsNewChatMembersHandler(IBotClient bot, ILogger<AbstractHandler<IsNewChatMembersRequest>> logger) : base(bot, logger)
        {
        }

        public override async Task<Unit> Handle(IsNewChatMembersRequest request, CancellationToken cancellationToken)
        {
            var update = request.Update;
            
            var message = update.Message;
            
            foreach (var user in message.NewChatMembers)
            {
                if (!user.IsBot)
                {
                    await Bot.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: $"Bienvenido @{user.Username} a la noble causa del bolivarismo.",
                        cancellationToken: cancellationToken);
                }
            }
            
            return Unit.Value;
        }
    }
}