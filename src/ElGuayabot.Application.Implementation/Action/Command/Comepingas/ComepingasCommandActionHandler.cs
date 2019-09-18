using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Implementation.Common.Response.Text;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ElGuayabot.Application.Implementation.Action.Command.Comepingas
{
    public class ComepingasCommandActionHandler : CommonHandler<ComepingasCommandAction, Result>
    {
        public ComepingasCommandActionHandler(ILogger<CommonHandler<ComepingasCommandAction, Result>> logger, IMediator mediatR) : base(logger, mediatR)
        {
        }

        public override async Task<Result> Handle(ComepingasCommandAction request, CancellationToken cancellationToken)
        {
            var responses = new List<string>
            {
                "zampavergas", "ingierepitos", "mascacipotes", "devorafalos", "meriendachorras", "almuerzapollas", "consumerabos", "cenapuntas", 
                "degustavaras", "roemingas", "embocachurras", "yantapenes", "picatrancas", "desgastapichas", "saboreacucas", "catamangos", 
                "succionaporras", "relamepijas", "bebelefas", "absorbeleches", "chupapepinos", "extraejugos", "cagapalos", "mamagüevo", "mochador", 
                "tragabolas", "limpiasables", "comepingas", "engullenabos"
            };
            
            var rnd = new Random();

            var r = rnd.Next(responses.Count);

            var selectedResponse = responses[r];

            var recipient = SelectRecipient(request.Message);

            var response = $"{recipient} <b>{selectedResponse}</b>";

            return await MediatR.Send(new TextResponse(response));

        }
        
        private string SelectRecipient(Message message)
        {
            if (message.Entities.Any(m => m.Type == MessageEntityType.Mention))
            {
                var user = message.EntityValues.First(m => m.StartsWith("@"));
                
                return $"{user} eres un";
            }

            if (message.Entities.Any(m => m.Type == MessageEntityType.TextMention))
            {
                var user = message.Entities.First(m => m.Type == MessageEntityType.TextMention).User.FirstName;
                return $"<i>{user}</i> eres un";

            }
            
            return "Todos <i>ustedes</i> son unos";
        }
    }
}