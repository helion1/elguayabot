using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Contract.Common.Context;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayabot.Application.Implementation.Common.Response.Photo
{
    public class PhotoResponseHandler : CommonHandler<PhotoResponse, Result>
    {
        protected readonly IBotContext BotContext;
        
        public PhotoResponseHandler(ILogger<CommonHandler<PhotoResponse, Result>> logger, IMediator mediatR, IBotContext botContext) : base(logger, mediatR)
        {
            BotContext = botContext;
        }

        public override async Task<Result> Handle(PhotoResponse request, CancellationToken cancellationToken)
        {
            try
            {
                await BotContext.BotClient.Client.SendPhotoAsync(BotContext.Chat.Id, request.Photo, cancellationToken: cancellationToken);

                return Result.Success();
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Unhandled error sending photo ({@Request}).", request);
                
                return Result.UnknownError(new List<string> {e.Message});
            }
        }
    }
}