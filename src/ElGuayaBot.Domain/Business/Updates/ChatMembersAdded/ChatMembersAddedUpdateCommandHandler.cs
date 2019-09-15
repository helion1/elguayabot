using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Common.Result;
using ElGuayaBot.Domain.Business.ChatsUsers.RegisterUserChat;
using ElGuayaBot.Domain.Business.Notifications;
using ElGuayaBot.Domain.Entity;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Domain.Business.Updates.ChatMembersAdded
{
    public class ChatMembersAddedUpdateCommandHandler : ElGuayaBot.Common.Request.RequestHandler<ChatMembersAddedUpdateCommand, Result>
    {
        public ChatMembersAddedUpdateCommandHandler(ILogger<ElGuayaBot.Common.Request.RequestHandler<ChatMembersAddedUpdateCommand, Result>> logger, IMediator mediatR) : base(logger, mediatR)
        {
        }

        public override async Task<Result> Handle(ChatMembersAddedUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newUsers = request.NewChatMembers.Where(chatMember => !chatMember.IsBot).ToList();
    
                var message = "Bienvenido a la noble causa del bolivarismo.";
                
                if (newUsers.Count() == 1)
                {
                    message = $"Bienvenido @{newUsers.First().Username} a la noble causa del bolivarismo.";
                }
                else if (newUsers.Count > 1)
                {
//                    var usernames = newUsers.Select(user => user.Username).ToList();
                    //TODO: get all usernames
                    message = $"Bienvenidos todos a la noble causa del bolivarismo.";
                }
    
                foreach (var newUser in newUsers)
                {
                    await MediatR.Send(new RegisterChatUserCommand()
                    {
                        User = newUser,
                        Chat = new Chat(){ Id = request.Id}
                    });
                }
                
                await MediatR.Publish(new SendMessage()
                {
                    ChatId = request.ChatId,
                    Message = message
                });
            }
            catch (Exception e)
            {
                Logger.LogError("Handler for 'ChatMembersAddedUpdateCommand' encountered an unknown error", e);
            }

            return Result.Success();
        }
    }
}