using System.Linq;
using ElGuayaBot.Domain.Business.ChatsUsers.RegisterUserChat;
using ElGuayaBot.Domain.Business.Requests;
using ElGuayaBot.Domain.Business.Updates.Common;
using ElGuayaBot.Domain.Entity;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Domain.Business.Updates
{
    public class UpdateNotificationChatMembersAddedHandler : NotificationHandler<UpdateCommand>
    {
        private readonly Logger<UpdateNotificationChatMembersAddedHandler> Logger;
        private readonly IMediator _mediatR;

        public UpdateNotificationChatMembersAddedHandler(Logger<UpdateNotificationChatMembersAddedHandler> logger, IMediator mediatR)
        {
            Logger = logger;
            _mediatR = mediatR;
        }

        protected override void Handle(UpdateCommand command)
        {
            if (command.Type != UpdateType.ChatMembersAdded) return;
            Logger.LogTrace($"ChatMembersAdded update handler triggered.");

            var newUsers = command.NewChatMembers.Where(chatMember => !chatMember.IsBot).ToList();

            var message = "Bienvenido a la noble causa del bolivarismo.";
            
            if (newUsers.Count() == 1)
            {
                message = $"Bienvenido @{newUsers.First().Username} a la noble causa del bolivarismo.";
            }
            else if (newUsers.Count > 1)
            {
//                var usernames = newUsers.Select(user => user.Username).ToList();
                //TODO: get all usernames
                message = $"Bienvenidos todos a la noble causa del bolivarismo.";
            }

            _mediatR.Publish(new SendMessageRequest()
            {
                ChatId = command.ChatId,
                Message = message
            });

            foreach (var newUser in newUsers)
            {
                _mediatR.Send(new RegisterChatUserCommand()
                {
                    User = newUser,
                    Chat = new Chat(){ Id = command.Id}
                });
            }
        }
    }
}