using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Implementation.Common.Response.Sticker;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayabot.Application.Implementation.Action.Command.Savage
{
    public class SavageCommandActionHandler : CommonHandler<SavageCommandAction, Result>
    {
        public SavageCommandActionHandler(ILogger<CommonHandler<SavageCommandAction, Result>> logger, IMediator mediatR) : base(logger, mediatR)
        {
        }

        public override async Task<Result> Handle(SavageCommandAction request, CancellationToken cancellationToken)
        { 
            var stickers = new[]
            {
                "CAADBAADCwADDdKGArkc1pQ76UjOAg",
                "CAADBAADCAADDdKGAj_tC5h436A2Ag",
                "CAADBAADBQADDdKGAv0V8UL31iekAg",
                "CAADBAADBwADDdKGAubVZoG_YKlWAg",
                "CAADBAADAgADDdKGAgcifxalwaDKAg",
                "CAADBAADBAADDdKGAjr0hGT_J4u3Ag",
                "CAADBAADBgADDdKGAqe9xdJ4y-V6Ag",
                "CAADBAADJAADDdKGAhUI62q4Q-eiAg",
                "CAADAgADQAUAAog4OAKdFs7BU_FNjQI",
                "CAADAQADlgMAAjnUfAkos0drWCawrAI",
                "CAADAQADmQIAAjnUfAnE0K1G3myfjwI",
                "CAADAQADdgIAAjnUfAkZEhBnIIzuqAI",
                "CAADAQADiAIAAjnUfAleZXX-v7oW4wI",
                "CAADAQADYQIAAjnUfAn6QZUuV2w1_QI",
                "CAADBAADKwEAAh0jyRTxsVe5q0mezwI",
                "CAADBAADZQEAAh0jyRT_IHrp8Min1wI",
                "CAADBAADcQEAAh0jyRRpT-gqOeTdiQI",
                "CAADBAADcgEAAh0jyRSlvWxWXM1hIQI",
                "CAADBAADegEAAh0jyRT59lf9Ujs4NgI",
                "CAADAQADFAADtRhUDotYyJnp5TPwAg",
                "CAADBAADej0AAnrRWwb0PeNFoICsSQI",
                "CAADBAADewUAAlthFwNM1PJc-dzS5AI",
                "CAADAgADEwAD0lqIASWkmUvWWXbPAg"
            };
            
            var rnd = new Random();

            var n = rnd.Next(stickers.Length);

            var luckySticker = stickers[n];

            return await MediatR.Send(new StickerResponse(luckySticker), cancellationToken);
        }
    }
}