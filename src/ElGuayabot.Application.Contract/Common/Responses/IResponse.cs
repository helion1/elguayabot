using MediatR;
using TheWeatherman.Common.Result;

namespace ElGuayabot.Application.Contract.Common.Responses
{
    public interface IResponse : IRequest<Result>
    {
    }
}