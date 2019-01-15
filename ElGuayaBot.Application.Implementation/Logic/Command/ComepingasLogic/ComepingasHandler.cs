using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ElGuayaBot.Application.Implementation.Logic.Command.ComepingasLogic
{
    public class ComepingasHandler : AbstractHandler<ComepingasRequest>
    {
        public ComepingasHandler(IBotClient bot, ILogger<AbstractHandler<ComepingasRequest>> logger) : base(bot, logger)
        {
        }

        public override async Task<Unit> Handle(ComepingasRequest request, CancellationToken cancellationToken)
        {
            var message = request.Message;
            
            var responses = new List<string>
            {
                "zampavergas", "ingierepitos", "mascacipotes", "devorafalos", "meriendachorras", "almuerzapollas", "consumerabos", "cenapuntas", 
                "degustavaras", "roemingas", "embocachurras", "yantapenes", "picatrancas", "desgastapichas", "saboreacucas", "catamangos", 
                "succionaporras", "relamepijas", "bebelefas", "absorbeleches", "chupapepinos", "extraejugos", "cagapalos", "mamagüevo", "tragabolas", 
                "limpiasables", "comepingas", "engullenabos", "comestacas", "abrazapostes"
            };
            
            var rnd = new Random();

            var r = rnd.Next(responses.Count);

            var selectedResponse = responses[r];

            var recipient = SelectRecipient(message);

            var response = $"{recipient} <b>{selectedResponse}</b>";
            
            await Bot.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: response,
                parseMode: ParseMode.Html,
                cancellationToken: cancellationToken);
            
            return Unit.Value;
        }

        private string SelectRecipient(Message message)
        {
            if (message.Entities.Any(m => m.Type == MessageEntityType.Mention))
            {
                var user = message.EntityValues.First(m => m.StartsWith("@"));

                return user.ToLower() != "@elguayabot" ? $"{user} eres un" : $"@{message.From.Username} eres un maldito";
            }

            if (message.Entities.Any(m => m.Type == MessageEntityType.TextMention))
            {
                var user = message.Entities.First(m => m.Type == MessageEntityType.TextMention).User.FirstName;
                
                return $"<i>{user}</i> eres un";
            }
            
            return "Todos <i>ustedes</i> son unos malditos";
        }
    }
}