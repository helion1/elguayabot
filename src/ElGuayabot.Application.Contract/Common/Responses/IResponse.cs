using ElGuayabot.Common.Result;
using MediatR;

namespace ElGuayabot.Application.Contract.Common.Responses
{
    public interface IResponse : IRequest<Result>
    {
    }
}