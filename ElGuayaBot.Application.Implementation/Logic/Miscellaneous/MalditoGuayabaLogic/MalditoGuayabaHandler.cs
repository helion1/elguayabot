using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayaBot.Application.Implementation.Logic.Miscellaneous.MalditoGuayabaLogic
{
    public class MalditoGuayabaHandler : AbstractHandler<MalditoGuayabaRequest>
    {
        public MalditoGuayabaHandler(IBotClient bot, ILogger<AbstractHandler<MalditoGuayabaRequest>> logger) : base(bot, logger)
        {
        }

        public override async Task<Unit> Handle(MalditoGuayabaRequest request, CancellationToken cancellationToken)
        {
            //TODO
//            string[] gifs = { "CgADBAADpwQAAv5ngVGtCPQFsb8tdAI", "CgADBAADqgQAAmU3gFHy16mGSB-vaQI", "CgADBAADqwQAAmU3gFF-jYzn6DPQcgI" };
//            try
//            {
//                var rnd = new Random();
//
//                await _bot.SendDocumentAsync(
//                    chatId: message.Chat.Id,
//                    document: gifs[GetRandomNumber()],
//                    replyToMessageId: message.MessageId
//                );
//            }
//            catch (Exception)
//            {
//
//                throw;
//            }

            return Unit.Value;
        }
    }
}