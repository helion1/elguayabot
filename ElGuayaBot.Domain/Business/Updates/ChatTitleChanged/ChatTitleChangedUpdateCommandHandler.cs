using System;
using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Common.Result;
using ElGuayaBot.Domain.Business.Chats.ChangeChatTitle;
using ElGuayaBot.Domain.Business.Requests;
using ElGuayaBot.Domain.Business.Updates.Common;
using ElGuayaBot.Persistence.Contract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Domain.Business.Updates.ChatTitleChanged
{
    public class ChatTitleChangedUpdateCommandHandler : ElGuayaBot.Common.Request.RequestHandler<ChatTitleChangedUpdateCommand, Result>
    {
        public ChatTitleChangedUpdateCommandHandler(ILogger<ElGuayaBot.Common.Request.RequestHandler<ChatTitleChangedUpdateCommand, Result>> logger, IMediator mediatR) : base(logger, mediatR)
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

                await MediatR.Publish(new SendMessageRequest()
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
