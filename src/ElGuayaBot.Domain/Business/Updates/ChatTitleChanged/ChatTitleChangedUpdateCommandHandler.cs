using System;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Common.Result;
using ElGuayabot.Domain.Business.Chats.ChangeChatTitle;
using ElGuayabot.Domain.Business.Notifications;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayabot.Domain.Business.Updates.ChatTitleChanged
{
    public class ChatTitleChangedUpdateCommandHandler : ElGuayabot.Common.Request.RequestHandler<ChatTitleChangedUpdateCommand, Result>
    {
        public ChatTitleChangedUpdateCommandHandler(ILogger<ElGuayabot.Common.Request.RequestHandler<ChatTitleChangedUpdateCommand, Result>> logger, IMediator mediatR) : base(logger, mediatR)
        {
        }

        public override async Task<Result> Handle(ChatTitleChangedUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await MediatR.Send(new ChangeChatTitleCommand()
                {
                    ChatId = request.ChatId,
                    NewChatTitle = request.NewChatTitle
                });

                await MediatR.Publish(new SendMessage()
                {
                    ChatId = request.ChatId,
                    Message = "¡Vergación! 😱 El nuevo título del chat esta bien ahuevonado"
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return Result.Success();
        }
    }
}
