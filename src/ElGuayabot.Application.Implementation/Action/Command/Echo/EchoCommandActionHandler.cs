using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Implementation.Common.Response.Text;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayabot.Application.Implementation.Action.Command.Echo
{
    public class EchoCommandActionHandler : CommonHandler<EchoCommandAction, Result>
    {
        public EchoCommandActionHandler(ILogger<CommonHandler<EchoCommandAction, Result>> logger, IMediator mediatR) : base(logger, mediatR)
        {
        }

        public override async Task<Result> Handle(EchoCommandAction request, CancellationToken cancellationToken)
        {
            var text = request.Text.Substring(request.Text.IndexOf(' ') + 1);

            if (text != request.Text && text.Trim() != "")
            {
                return await MediatR.Send(new TextResponse(text), cancellationToken);
            }
            
            return Result.Success();
        }
    }
}