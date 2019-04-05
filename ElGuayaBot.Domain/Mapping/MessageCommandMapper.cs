using ElGuayaBot.Domain.Business.BotCommands.About;
using ElGuayaBot.Domain.Business.BotCommands.Common;
using ElGuayaBot.Domain.Business.BotCommands.Other;
using ElGuayaBot.Domain.Business.Messages;

namespace ElGuayaBot.Domain.Mapping
{
    public static class MessageCommandMapper
    {
        public static BotCommand ToBotCommand(this MessageCommand messageCommand)
        {
            var botCommand = new BotCommand()
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
                    return botCommand as AboutCommand;
                default:
                    return botCommand as OtherCommand;
            }
        }
    }
}