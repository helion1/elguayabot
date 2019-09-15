using ElGuayabot.Application.Contract.BotActions.Common;
using TheWeatherman.Common.Result;

namespace ElGuayabot.Application.Contract.Common.Strategy
{
    public interface IBotActionSelector
    {
        Result<ICommandAction> GetCommandAction();
        Result<ICallbackAction> GetCallbackAction();
        Result<IInlineAction> GetInlineAction();
    }
}