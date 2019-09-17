using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Common.Result;
using ElGuayabot.Domain.Mapping;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayabot.Domain.Business.Messages
{
    public class MessageCommandHandler : Common.Request.CommonHandler<MessageCommand, Result>
    {
        public MessageCommandHandler(ILogger<Common.Request.CommonHandler<MessageCommand, Result>> logger, IMediator mediatR) : base(logger, mediatR)
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