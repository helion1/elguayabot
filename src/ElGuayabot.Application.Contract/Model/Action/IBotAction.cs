using ElGuayabot.Common.Result;
using MediatR;
using Telegram.Bot.Types;

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