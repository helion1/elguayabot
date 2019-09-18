//using System;
//using System.Collections.Generic;
//using System.Threading;
//using System.Threading.Tasks;
//using ElGuayabot.Application.Contract.Client;
//using ElGuayabot.Application.Implementation.Logic.Common.AbstractLogic;
//using MediatR;
//using Microsoft.Extensions.Logging;
//
//namespace ElGuayabot.Application.Implementation.Logic.Command.SavageLogic
//{
//    public class SavageHandler : AbstractHandler<SavageRequest>
//    {
//        public SavageHandler(IBotClient bot, ILogger<AbstractHandler<SavageRequest>> logger) : base(bot, logger)
//        {
//        }
//
//        public override async Task<Unit> Handle(SavageRequest request, CancellationToken cancellationToken)
//        {
//            var message = request.Message;
//
//            var stickers = new List<string>
//            {
//                "CAADBAADCwADDdKGArkc1pQ76UjOAg",
//                "CAADBAADCAADDdKGAj_tC5h436A2Ag",
//                "CAADBAADBQADDdKGAv0V8UL31iekAg",
//                "CAADBAADBwADDdKGAubVZoG_YKlWAg",
//                "CAADBAADAgADDdKGAgcifxalwaDKAg",
//                "CAADBAADBAADDdKGAjr0hGT_J4u3Ag",
//                "CAADBAADBgADDdKGAqe9xdJ4y-V6Ag",
//                "CAADBAADJAADDdKGAhUI62q4Q-eiAg",
//                "CAADAgADQAUAAog4OAKdFs7BU_FNjQI",
//                "CAADAQADlgMAAjnUfAkos0drWCawrAI",
//                "CAADAQADmQIAAjnUfAnE0K1G3myfjwI",
//                "CAADAQADdgIAAjnUfAkZEhBnIIzuqAI",
//                "CAADAQADiAIAAjnUfAleZXX-v7oW4wI",
//                "CAADAQADYQIAAjnUfAn6QZUuV2w1_QI",
//                "CAADBAADKwEAAh0jyRTxsVe5q0mezwI",
//                "CAADBAADZQEAAh0jyRT_IHrp8Min1wI",
//                "CAADBAADcQEAAh0jyRRpT-gqOeTdiQI",
//                "CAADBAADcgEAAh0jyRSlvWxWXM1hIQI",
//                "CAADBAADegEAAh0jyRT59lf9Ujs4NgI",
//                "CAADAQADFAADtRhUDotYyJnp5TPwAg",
//                "CAADBAADej0AAnrRWwb0PeNFoICsSQI",
//                "CAADBAADewUAAlthFwNM1PJc-dzS5AI",
//                "CAADAgADEwAD0lqIASWkmUvWWXbPAg"
//            };
//            
//            var rnd = new Random();
//
//            var r = rnd.Next(stickers.Count);
//
//            await Bot.SendStickerAsync(
//                chatId: message.Chat.Id,
//                sticker: stickers[r],
//                cancellationToken: cancellationToken);
//            
//            return Unit.Value;
//        }
//    }
//}