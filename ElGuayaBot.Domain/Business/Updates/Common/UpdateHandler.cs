using System;
using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Common.Request;
using ElGuayaBot.Common.Result;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Domain.Business.Updates.Common
{
    public abstract class UpdateHandler<T> : ElGuayaBot.Common.Request.RequestHandler<T, Result> where T : Request<Result>
    {
        protected ElGuayaBot.Common.Request.RequestHandler<T, Result> RequestHandlerImplementation;

        public UpdateHandler(ILogger<ElGuayaBot.Common.Request.RequestHandler<T, Result>> logger, IMediator mediatR) : base(logger, mediatR)
        {
        }

        public override async Task<Result> Handle(T request, CancellationToken cancellationToken)
        {
            var result = default(Result);
            
            try
            {
                result = await RequestHandlerImplementation.Handle(request, cancellationToken);
            }
            catch (Exception e)
            {
                var name = typeof(T).Name;
                Logger.LogError($"Update ({name} encountered an unknown error", e);
            }

            return result;
        }
    }
}