using System.Collections.Generic;
using ElGuayabot.Application.Contract.Common.Context;
using Newtonsoft.Json;

namespace ElGuayabot.Application.Contract.Model.Action.Callback
{
    public abstract class CallbackAction : BotAction, ICallbackAction
    {
        public Dictionary<string, string> Data { get; set; }

        public CallbackAction(IBotContext botContext) : base(botContext)
        {
            Dictionary<string, string> callbackData;
            try
            {
                callbackData = JsonConvert.DeserializeObject<Dictionary<string, string>>(botContext.CallbackQuery.Data);
            }
            catch
            {
                callbackData = new Dictionary<string, string>();
            }

            Data = callbackData;
        }
    }
}