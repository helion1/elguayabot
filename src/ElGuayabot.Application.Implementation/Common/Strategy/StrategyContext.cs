using System.Collections.Generic;
using ElGuayabot.Application.Contract.Common.Strategy;
using ElGuayabot.Application.Contract.Model.Action.Callback;
using ElGuayabot.Application.Contract.Model.Action.Command;
using ElGuayabot.Application.Contract.Model.Action.Inline;
using ElGuayabot.Application.Contract.Model.Action.Miscellaneous;

namespace ElGuayabot.Application.Implementation.Common.Strategy
{
    public class StrategyContext : IStrategyContext
    {
        protected IEnumerable<IMiscellaneousAction> MiscellaneousActions;
        protected IEnumerable<ICallbackAction> CallbackActions;
        protected IEnumerable<ICommandAction> CommandActions;
        protected IEnumerable<IInlineAction> InlineActions;

        public StrategyContext(IEnumerable<IMiscellaneousAction> miscellaneousActions, IEnumerable<ICallbackAction> callbackActions, IEnumerable<ICommandAction> commandActions, IEnumerable<IInlineAction> inlineActions)
        {
            MiscellaneousActions = miscellaneousActions;
            CallbackActions = callbackActions;
            CommandActions = commandActions;
            InlineActions = inlineActions;
        }

        public IEnumerable<IMiscellaneousAction> GetMiscellaneousStrategyContext()
        {
            return MiscellaneousActions;
        }
        
        public IEnumerable<ICallbackAction> GetCallbackStrategyContext()
        {
            return CallbackActions;
        }

        public IEnumerable<ICommandAction> GetCommandStrategyContext()
        {
            return CommandActions;
        }

        public IEnumerable<IInlineAction> GetInlineStrategyContext()
        {
            return InlineActions;
        }
    }
}