using ElGuayaBot.Domain.Business.BotActions.CommandActions.About;
using ElGuayaBot.Domain.Business.BotActions.CommandActions.Other;
using ElGuayaBot.Domain.Business.BotActions.Common;
using ElGuayaBot.Domain.Business.Messages;

namespace ElGuayaBot.Domain.Mapping
{
    public static class MessageCommandMapper
    {
        public static BotAction ToBotCommandAction(this MessageCommand messageCommand)
        {
            var botCommand = new BotAction()
            {
                MessageId = messageCommand.Id,
                Chat = messageCommand.Chat,
                From = messageCommand.From,
                Text = messageCommand.Text,
                Urls = messageCommand.Urls,
                Mentions = messageCommand.Mentions
            };
            
            switch (messageCommand.Command)
            {
                case "/about":
                    return botCommand as AboutCommandAction;
                default:
                    return botCommand as OtherCommandAction;
            }
        }

    }
}