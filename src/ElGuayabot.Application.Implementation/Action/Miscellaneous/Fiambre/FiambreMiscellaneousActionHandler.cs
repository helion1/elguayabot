using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Implementation.Common.Response.Text;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayabot.Application.Implementation.Action.Miscellaneous.Fiambre
{
    public class FiambreMiscellaneousActionHandler : CommonHandler<FiambreMiscellaneousAction, Result>
    {
        public FiambreMiscellaneousActionHandler(ILogger<CommonHandler<FiambreMiscellaneousAction, Result>> logger, IMediator mediatR) : base(logger, mediatR)
        {
        }

        public override async Task<Result> Handle(FiambreMiscellaneousAction request, CancellationToken cancellationToken)
        {
            return await MediatR.Send(new TextResponse("pues aquí hay fiambre JAJAJAJAJAJA")); //TODO: reply
        }
    }
}