using ElGuayabot.Application.Contract.Model.Action.Callback;
using ElGuayabot.Application.Contract.Model.Action.Command;
using ElGuayabot.Application.Contract.Model.Action.Inline;
using ElGuayabot.Application.Contract.Model.Action.Miscellaneous;
using ElGuayabot.Common.Result;

namespace ElGuayabot.Application.Contract.Common.Strategy
{
    public interface IBotActionSelector
    {
        Result<ICommandAction> GetCommandAction();
        Result<IMiscellaneousAction> GetMiscellaneousAction();
        Result<ICallbackAction> GetCallbackAction();
        Result<IInlineAction> GetInlineAction();
    }
}