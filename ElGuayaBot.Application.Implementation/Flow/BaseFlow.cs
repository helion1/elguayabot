using System;
using ElGuayaBot.Application.Contracts;
using ElGuayaBot.Application.Contracts.Flow;
using NeoSmart.Unicode;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ElGuayaBot.Application.Implementation.Flow
{
    public abstract class BaseFlow: IBaseFlow
    {
        protected static Random Rnd { get; set; }

        protected readonly ITelegramBotClient _bot;

        public BaseFlow(IBotClient bot)
        {
            _bot = bot.Client ?? throw new ArgumentNullException(nameof(bot));
            Rnd = new Random();
        }
        
        public bool IsAllUpper(string input)
        {
            var containsLetters = false;
            if (Emoji.IsEmoji((input)))
            {
                return false;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsLetter(input[i]))
                {
                    containsLetters = true;
                }
            }
            
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsLetter(input[i]) && !Char.IsUpper(input[i]))
                    return false;
            }
            
            return containsLetters;
        }

        public abstract void Initiate(Message message);
    }
}