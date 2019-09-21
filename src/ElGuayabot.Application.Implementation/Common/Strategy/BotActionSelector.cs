using System;
using System.Collections.Generic;
using System.Linq;
using ElGuayabot.Application.Contract.Common.Context;
using ElGuayabot.Application.Contract.Common.Strategy;
using ElGuayabot.Application.Contract.Model.Action.Callback;
using ElGuayabot.Application.Contract.Model.Action.Command;
using ElGuayabot.Application.Contract.Model.Action.Inline;
using ElGuayabot.Application.Contract.Model.Action.Miscellaneous;
using ElGuayabot.Application.Contract.Model.Action.Update;
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
            var text = BotContext.Message.Text;
            
            if (text == null) return Result<IMiscellaneousAction>.NotFound(new List<string> {"No corresponding action found."});

            var action = StrategyContext.GetMiscellaneousStrategyContext().FirstOrDefault(botAction => botAction.CanHandle(text));

            if (action == null) return Result<IMiscellaneousAction>.NotFound(new List<string> {"No corresponding action found."});

            return Result<IMiscellaneousAction>.Success(action);
        }
        
        public Result<IUpdateAction> GetUpdateAction()
        {
            var updateType = GetUpdateType(BotContext.Update);
            
            if (updateType == null) return Result<IUpdateAction>.NotFound(new List<string> {"No corresponding action found."});

            var action = StrategyContext.GetUpdateStrategyContext().FirstOrDefault(botAction => botAction.CanHandle(updateType));
            
            if (action == null) return Result<IUpdateAction>.NotFound(new List<string> {"No corresponding action found."});

            return Result<IUpdateAction>.Success(action);
        }

        private string GetUpdateType(Update update)
        {
            return update.Type == UpdateType.Message
                ? update.Message.Type.ToString() 
                : update.Type.ToString();
        }
        
        private string GetCommand(Message message)
        {
            if (message.Entities?.First()?.Type != MessageEntityType.BotCommand) return null;
            
            var command = message.EntityValues.First();

            if (!command.Contains('@')) return command;
                
            if (!command.Contains(BotContext.BotName)) return null;

            command = command.Substring(0, command.IndexOf('@'));

            return command;
        }
    }
}