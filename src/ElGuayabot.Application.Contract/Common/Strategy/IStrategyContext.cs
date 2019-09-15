using System.Collections.Generic;
using ElGuayabot.Application.Contract.BotActions.Common;

namespace ElGuayabot.Application.Contract.Common.Strategy
{
    public interface IStrategyContext
    {
        IEnumerable<ICallbackAction> GetCallbackStrategyContext();
        IEnumerable<ICommandAction> GetCommandStrategyContext();
        IEnumerable<IInlineAction> GetInlineStrategyContext();
    }
}