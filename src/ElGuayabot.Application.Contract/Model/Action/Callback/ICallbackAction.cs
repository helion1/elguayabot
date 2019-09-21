using System.Collections.Generic;

namespace ElGuayabot.Application.Contract.Model.Action.Callback
{
    public interface ICallbackAction : IBotAction
    {
        Dictionary<string, string> Data { get; set; }
    }
}