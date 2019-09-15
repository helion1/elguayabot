using System.Collections.Generic;

namespace ElGuayabot.Application.Contract.BotActions.Common
{
    public interface ICallbackAction : IBotAction
    {
        Dictionary<string, string> Data { get; set; }
    }
}