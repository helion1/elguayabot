using System.Linq;
using ElGuayaBot.Domain.Business.Messages;
using ElGuayaBot.Domain.Business.UserChat.RegisterUserChat;
using ElGuayaBot.Domain.Entity;
using MediatR;

namespace ElGuayaBot.Domain.Business.Updates
{
    public class UpdateNotificationChatMembersAddedHandler : NotificationHandler<UpdateNotification>
    {
        private readonly IMediator _mediatR;

        public UpdateNotificationChatMembersAddedHandler(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        protected override void Handle(UpdateNotification notification)
        {
            if (notification.Type != UpdateType.ChatMembersAdded) return;

            var newUsers = notification.NewChatMembers.Where(chatMember => !chatMember.IsBot).ToList();

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
                ChatId = notification.ChatId,
                Message = message
            });

            foreach (var newUser in newUsers)
            {
                _mediatR.Send(new RegisterChatUserCommand()
                {
                    User = newUser,
                    Chat = new Chat(){ Id = notification.Id}
                });
            }
        }
    }
}