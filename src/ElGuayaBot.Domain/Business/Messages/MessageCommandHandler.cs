using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Common.Result;
using ElGuayaBot.Domain.Mapping;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Domain.Business.Messages
{
    public class MessageCommandHandler : Common.Request.RequestHandler<MessageCommand, Result>
    {
        public MessageCommandHandler(ILogger<Common.Request.RequestHandler<MessageCommand, Result>> logger, IMediator mediatR) : base(logger, mediatR)
        {
        }
        
        public override async Task<Result> Handle(MessageCommand request, CancellationToken cancellationToken)
        {
            if (request.Type != MessageType.Text) return Result.Success();

            if (request.Command != null)
            {
                return await MediatR.Send(request.ToBotCommandAction(), cancellationToken);
            }

            if (request.Urls.Length >= 1)
            {
                return await MediatR.Send(request.ToBotUrlAction(), cancellationToken);
            }
            
            return Result.Success();
        }
    }
}