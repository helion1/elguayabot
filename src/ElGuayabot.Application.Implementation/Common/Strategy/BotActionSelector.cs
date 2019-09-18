using System;
using System.Collections.Generic;
using System.Linq;
using ElGuayabot.Application.Contract.Common.Context;
using ElGuayabot.Application.Contract.Common.Strategy;
using ElGuayabot.Application.Contract.Model.Action.Callback;
using ElGuayabot.Application.Contract.Model.Action.Command;
using ElGuayabot.Application.Contract.Model.Action.Inline;
using ElGuayabot.Application.Contract.Model.Action.Miscellaneous;
using ElGuayabot.Common.Result;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ElGuayabot.Application.Implementation.Common.Strategy
{
    public class BotActionSelector : IBotActionSelector
    {
        protected readonly ILogger<BotActionSelector> Logger;
        protected readonly IStrategyContext StrategyContext;
        protected readonly IBotContext BotContext;

        public BotActionSelector(ILogger<BotActionSelector> logger, IStrategyContext strategyContext, IBotContext botContext)
        {
            Logger = logger;
            StrategyContext = strategyContext;
            BotContext = botContext;
        }

        public Result<ICommandAction> GetCommandAction()
        {            
            var command = GetCommand(BotContext.Message);
            
            if (command == null) return Result<ICommandAction>.NotFound(new List<string> {"No corresponding action found."});

            var action = StrategyContext.GetCommandStrategyContext().FirstOrDefault(botAction => botAction.CanHandle(command));

            if (action == null) return Result<ICommandAction>.NotFound(new List<string> {"No corresponding action found."});

            return Result<ICommandAction>.Success(action);
        }

        public Result<IMiscellaneousAction> GetMiscellaneousAction()
        {
            throw new NotImplementedException();
        }

        private string GetCommand(Message message)
        {
            if (message.Entities?.First()?.Type != MessageEntityType.BotCommand) return null;
            
            var command = message.EntityValues.First();

            if (!command.Contains('@')) return command;
                
            if (!command.ToLower().Contains("@pokegraf_bot")) return null;

            command = command.Substring(0, command.IndexOf('@'));

            return command;
        }
    }
}