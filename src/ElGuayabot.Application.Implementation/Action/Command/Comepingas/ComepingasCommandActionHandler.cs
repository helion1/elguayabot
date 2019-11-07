using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Implementation.Common.Response.Text;
using ElGuayabot.Common.Helper;
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
            var selectedResponse = InsultMaker();

            var recipient = SelectRecipient(request.Message);

            var response = $"{recipient} <b>{selectedResponse}</b>";

            return await MediatR.Send(new TextResponse(response, ParseMode.Html));
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

        private string InsultMaker()
        {
            var dickSynonyms = new[]
            {
                "vergas", "pitos", "cipotes", "falos", "chorras", "pollas", "rabos", "puntas",
                "varas", "mingas", "churras", "penes", "trancas", "pichas", "cucas", "mangos",
                "porras", "pijas", "lefas", "leches", "pepinos", "jugos", "palos", "güevos",
                "bolas", "sables", "pingas", "nabos", "testiculos", "cojones", "escrotos", "pelotas",
                "-partes íntimas masculinas", "genitales", "-órganos sexuales", "morcillas", "ciruelos",
                "semen", "miembros", "colas", "pililas", "porongas", "gansos", "garchas", "palancas",
                "calipos", "pirulos", "paquetes", "salchichas", "bratwursts", "pajaritos", "mastiles de carne",
                "trípodes", "rabos", "troncos", "flautas", "chorgas", "salami", "capullos", "glandes", "cimbreles",
                "trabucos", "plátanos", "colitas", "ñongas", "nepes"
            };

            var suckingSynonyms = new[]
            {
                "zampa", "ingiere", "masca", "devora", "merienda", "almuerza", "consume", "cena",
                "degusta", "roe", "emboca", "yanta", "pica", "desgasta", "saborea", "cata",
                "succiona", "relame", "bebe", "absorbe", "chupa", "extrae", "caga", "mama",
                "traga", "limpia", "come", "engulle", "desayuna", "sopla", "suca", "endurece",
                "besa", "chucla", "atrae", "empina", "sorbe", "siente", "disfruta", "goza", "empapa",
                "adora", "venera", "relame", "esnifa", "abraza", "apropia", "embebe", "chupetea",
                "bombea", "extenua", "aspira", "pimpla", "cautiva", "emplea", "seduce", "encaja",
                "anexa", "empotra", "afronta", "engrasa", "aborda", "afila", "corroe", "momifica",
                "besuquea", "acaricia", "babosea", "achucha", "soba"
            };

            var r1 = RandomProvider.GetThreadRandom().Next(suckingSynonyms.Length);
            var r2 = RandomProvider.GetThreadRandom().Next(dickSynonyms.Length);

            return String.Concat(suckingSynonyms[r1], dickSynonyms[r2]);
        }
    }
}