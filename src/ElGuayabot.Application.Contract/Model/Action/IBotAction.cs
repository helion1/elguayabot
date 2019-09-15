using MediatR;
using Telegram.Bot.Types;
using TheWeatherman.Common.Result;

namespace ElGuayabot.Application.Contract.Model.Action
{
    public interface IBotAction : IRequest<Result>
    {
        int MessageId { get; set; }
        Chat Chat { get; set; }
        User From { get; set; }
        string Text { get; set; }
        bool CanHandle(string condition);
    }
}