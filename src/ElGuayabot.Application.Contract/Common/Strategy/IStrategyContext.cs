using System.Collections.Generic;
using ElGuayabot.Application.Contract.Model.Action.Callback;
using ElGuayabot.Application.Contract.Model.Action.Command;
using ElGuayabot.Application.Contract.Model.Action.Inline;
using ElGuayabot.Application.Contract.Model.Action.Miscellaneous;
using ElGuayabot.Application.Contract.Model.Action.Update;

namespace ElGuayabot.Application.Contract.Common.Strategy
{
    public interface IStrategyContext
    {
        IEnumerable<IMiscellaneousAction> GetMiscellaneousStrategyContext();
        IEnumerable<ICallbackAction> GetCallbackStrategyContext();
        IEnumerable<ICommandAction> GetCommandStrategyContext();
        IEnumerable<IInlineAction> GetInlineStrategyContext();
        IEnumerable<IUpdateAction> GetUpdateStrategyContext();
    }
}