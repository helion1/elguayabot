using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Contract.Common.Context;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types.InputFiles;

namespace ElGuayabot.Application.Implementation.Common.Response.Document
{
    public class DocumentResponseHandler : CommonHandler<DocumentResponse, Result>
    {
        protected readonly IBotContext BotContext;

        public DocumentResponseHandler(ILogger<CommonHandler<DocumentResponse, Result>> logger, IMediator mediatR, IBotContext botContext) : base(logger, mediatR)
        {
            BotContext = botContext;
        }

        public override async Task<Result> Handle(DocumentResponse request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.MessageId != 0)
                {
                    await BotContext.BotClient.Client.SendDocumentAsync(BotContext.Chat.Id, request.Document as InputOnlineFile, 
                        replyToMessageId: request.MessageId, 
                        cancellationToken: cancellationToken);
                }
                else
                {
                    await BotContext.BotClient.Client.SendDocumentAsync(BotContext.Chat.Id, request.Document as InputOnlineFile, 
                        cancellationToken: cancellationToken);
                }

                return Result.Success();
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Unhandled error sending text response ({@Request}).", request);
                
                return Result.UnknownError(new List<string> {e.Message});
            }
        }
    }
}