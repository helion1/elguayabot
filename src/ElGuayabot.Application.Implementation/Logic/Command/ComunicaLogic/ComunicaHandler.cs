using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Contract.Client;
using ElGuayabot.Application.Contract.Service;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ElGuayaBot.Application.Implementation.Logic.Command.ComunicaLogic
{
    public class ComunicaHandler : AbstractHandler<ComunicaRequest>
    {
        private readonly IChatService _chatService;

        public ComunicaHandler(IBotClient bot, ILogger<AbstractHandler<ComunicaRequest>> logger, IChatService chatService) : base(bot, logger)
        {
            _chatService = chatService;
        }

        public override async Task<Unit> Handle(ComunicaRequest request, CancellationToken cancellationToken)
        {
            var message = request.Message;
            
            var restOfText = message.Text.Substring(message.Text.IndexOf(' ') + 1);

            if (restOfText == message.Text || restOfText.Trim() == "" || !UserHasRights(message))
            {
                return Unit.Value;
            }

            try
            {
                var sb = new StringBuilder( "<b>El Guayaba Comunica:</b> ");
                    
                sb.Append("<i>");
                sb.Append(restOfText);
                sb.Append("</i>");

                var comunicaMessage = sb.ToString();

                var chats = _chatService.GetGroupAndSupergroupChats();

                foreach (var chat in chats)
                {
                    var messageSent = await SendGuayabaComunicaMessage(chat.Id, comunicaMessage, cancellationToken);

                    if (chat.Type == ChatType.Supergroup.ToString())
                    {
                        await PinGuayabaComunicaMessage(messageSent, cancellationToken);                            
                    }
                }
            }
            catch (Exception e)
            {
                Logger.LogError("Error handling Guayaba Comunica request", e);
            }

            return Unit.Value;
        }

        private bool UserHasRights(Message message)
        {
            //TODO: Move this to config/resource file
            var usersWithRights = new List<int>
            {
                489047400, // ElGuayaba
                7089483, // Elementh
                42711 // Zabrios
            };

            return usersWithRights.Contains(message.From.Id);
        }

        private async Task<Message> SendGuayabaComunicaMessage(long chatId, string comunicaMessage, CancellationToken cancellationToken)
        {
            var messageSent = await Bot.SendTextMessageAsync(
                chatId: chatId,
                text: comunicaMessage,
                parseMode: ParseMode.Html, 
                cancellationToken: cancellationToken);

            return messageSent;
        }

        private async Task PinGuayabaComunicaMessage(Message message, CancellationToken cancellationToken)
        {
            try
            {
                await Bot.PinChatMessageAsync(
                    chatId: message.Chat.Id,
                    messageId: message.MessageId,
                    cancellationToken: cancellationToken);
            }
            catch (Exception e)
            {
                Logger.LogWarning($"Guayaba Comunica message was not pinned for chat with id: {message.Chat.Id}", e);
            }
        }
    }
}