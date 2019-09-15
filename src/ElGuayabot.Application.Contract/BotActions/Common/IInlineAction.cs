namespace ElGuayabot.Application.Contract.BotActions.Common
{
    public interface IInlineAction : IBotAction
    {
        string Query { get; set; }
        string Offset { get; set; }
    }
}