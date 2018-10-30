using System;
using System.Collections.Generic;
using System.Linq;
using ElGuayaBot.Application.Contracts;
using ElGuayaBot.Application.Contracts.Flow;
using Telegram.Bot.Types;

namespace ElGuayaBot.Application.Implementation.Flow
{
    public class RandomTextFlowService: BaseFlowService, IRandomTextFlowService
    {

        public RandomTextFlowService(IBotClient bot) : base(bot)
        {
        }

        public void PatternRecognizer(Message message)
        {
            var text = message.Text;

            if (text.ToLower().Contains("al final me mosqueo"))
            {
                AlFinalMeMosqueo(message);
            } else if (text.ToLower().Contains("nacionalidad"))
            {
                Nacionalidad(message);
            } else if (text.ToLower().Contains(":("))
            {
                NoEstesTriste(message);
            }
        }

        private async void NoEstesTriste(Message message)
        {
            var responses = new List<string>()
            {
                "Mi vida ya es lo suficientemente miserable como para que tu estes triste",
                "Al menos puedes comprar papel de vater",
                "¿Tu agua también tiene malaria?",
                "Al menos no compras GigaByte"
            };
            
            var r = Rnd.Next(responses.Count);
                
            await _bot.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: responses[r],
                replyToMessageId: message.MessageId
            );
        }

        private async void Nacionalidad(Message message)
        {
            var responses = new List<string>()
            {
                "La primera gestoría no valió de nada",
                "Cuando pedi el de la segunda me llego el de la primera",
                "Fuí victima de racismo",
                "Soy español, queridos compradres",
                "llegué el 19 de mayo y me lo dieron hace una semana",
                "Tan solo he necesitado 5 meses y 3 días para obtener la nacionalidad",
                "en teoría si es por primera vez y tienes todos los recaudos tardas un solo día"
            };
            
            var r = Rnd.Next(responses.Count);
                
            await _bot.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: responses[r],
                replyToMessageId: message.MessageId
            );
        }

        private async void AlFinalMeMosqueo(Message message)
        {
            var responses = new List<string>()
            {
                "At the end I will fly",
                "Get the fuck out, bitch",
                "I'm gonna get mad",
                "At late I'll fly",
                "Finally, I turn into a fly",
                "You are pissing me off",
                "At the end I will get flyed",
                "In the finish, I give tollinas",
                "In the end, I become a fly",
                "At least I'm being angry",
                "To the end I fly myself",
                "At the end I fucking shit",
                "To him ending my flyize",
                "At the end I'm flied, of nothing",
                "In the end I'll be a fly",
                "At the end, I fly myself",
                "I'm getting fly",
                "At last, I fly it",
                "At last, I became The Fly",
                "A hug strong",
                "To the end I enfly myself",
                "I will turn myself into a fly",
                "I believe I can fly",
                "I would end up pissing off",
                "I believe I can fly",
                "At the end, I will fly myself on",
                "In di end aim flaiin"
            };
                
            var r = Rnd.Next(responses.Count);
                
            await _bot.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: responses[r],
                replyToMessageId: message.MessageId
            );

        }
    }
}