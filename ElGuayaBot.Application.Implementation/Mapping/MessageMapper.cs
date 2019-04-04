using System;
using ElGuayaBot.Domain.Business.Messages;
using ElGuayaBot.Domain.Business.Updates;
using Telegram.Bot.Types;

namespace ElGuayaBot.Application.Implementation.Mapping
{
    public static class MessageMapper
    {
        public static MessageNotification ToNotification(this Message message)
        {
            return new MessageNotification()
            {
                Id = message.MessageId,
                Type = GetType(message),
                Chat = message.Chat.ToDomain(),
                From = message.From.ToDomain(),
                Text = message.Text,
                Command = GetCommand(message),
                Urls = GetUrls(message),
                Mentions = GetMentions(message)
            };
        }

        private static MessageType GetType(Message message)
        {
            switch (message.Type)
            {
                case Telegram.Bot.Types.Enums.MessageType.Text:
                    return MessageType.Text;
                case Telegram.Bot.Types.Enums.MessageType.Photo:
                    return MessageType.Photo;
                case Telegram.Bot.Types.Enums.MessageType.Audio:
                    return MessageType.Audio;
                case Telegram.Bot.Types.Enums.MessageType.Video:
                    return MessageType.Video;
                case Telegram.Bot.Types.Enums.MessageType.Voice:
                    return MessageType.Voice;
                case Telegram.Bot.Types.Enums.MessageType.Document:
                    return MessageType.Document;
                case Telegram.Bot.Types.Enums.MessageType.Sticker:
                    return MessageType.Sticker;
                case Telegram.Bot.Types.Enums.MessageType.Location:
                    return MessageType.Location;
                default:
                    return MessageType.Other;
            }
        }
        
        private static string GetCommand(Message message)
        {
            throw new System.NotImplementedException();
        }

        private static Uri[] GetUrls(Message message)
        {
            throw new System.NotImplementedException();
        }
        
        private static string[] GetMentions(Message message)
        {
            throw new System.NotImplementedException();
        }
    }
}