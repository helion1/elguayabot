using System;
using System.Threading.Tasks;
using ElGuayabot.Application.Contract.Common.Client;
using ElGuayabot.Application.Contract.Common.Context;
using ElGuayabot.Application.Implementation.Mapping;
using ElGuayabot.Domain.Conversation.FindConversation;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using Chat = ElGuayabot.Domain.Entity.Chat;
using User = ElGuayabot.Domain.Entity.User;

namespace ElGuayabot.Application.Implementation.Common.Context
{
    public class BotContext : IBotContext
    {
        protected readonly ILogger<BotContext> Logger;
        protected readonly IMediator Mediator;
        public IBotClient BotClient { get; set; }

        public Message Message { get; set; }
        public CallbackQuery CallbackQuery { get; set; }
        public InlineQuery InlineQuery { get; set; }
        public User User { get; set; }
        public Chat Chat { get; set; }

        public BotContext(ILogger<BotContext> logger, IBotClient botClient, IMediator mediator)
        {
            Logger = logger;
            BotClient = botClient;
            Mediator = mediator;
        }

        public async Task Populate(Message message)
        {
            Message = message;
            
            var conversationResult = await Mediator.Send(message.MapToFindConversationQuery());

            if (!conversationResult.Succeeded)
            {
                if (!conversationResult.Errors.ContainsKey("not_found"))
                {
                    Logger.LogError("Could not populate context with message. @Errors", conversationResult.Errors);
                    throw new Exception("Error populating context");
                }

                await Mediator.Send(message.MapToAddConversationCommand());
                conversationResult = await Mediator.Send(message.MapToFindConversationQuery());
            }
            
            User = conversationResult.Value.User;
            Chat = conversationResult.Value.Chat;
            
            Logger.LogTrace("Populated BotContext with Message.", message);
        }
    }
}