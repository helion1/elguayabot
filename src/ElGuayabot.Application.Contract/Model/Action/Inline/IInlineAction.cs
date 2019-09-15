namespace ElGuayabot.Application.Contract.Model.Action.Inline
{
    public interface IInlineAction : IBotAction
    {
        string Query { get; set; }
        string Offset { get; set; }
    }
}