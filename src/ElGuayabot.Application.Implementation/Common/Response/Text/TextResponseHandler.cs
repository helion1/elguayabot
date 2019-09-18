using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Contract.Common.Context;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayabot.Application.Implementation.Common.Response.Text
{
    public class TextResponseHandler : CommonHandler<TextResponse, Result>
    {
        protected readonly IBotContext BotContext;

        public TextResponseHandler(ILogger<CommonHandler<TextResponse, Result>> logger, IMediator mediatR, IBotContext botContext) : base(logger, mediatR)
        {
            BotContext = botContext;
        }
        
        public override async Task<Result> Handle(TextResponse request, CancellationToken cancellationToken)
        {
            try
            {
                await BotContext.BotClient.Client.SendTextMessageAsync(BotContext.Chat.Id, request.Text, request.ParseMode, cancellationToken: cancellationToken);

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