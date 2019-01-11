using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using MihaZupan.TelegramBotClients;

namespace ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic
{
    public abstract class AbstractHandler<T>: IRequestHandler<T> where T : AbstractRequest
    {
        protected readonly BlockingTelegramBotClient Bot;

        private readonly ILogger _logger;

        protected AbstractHandler(BlockingTelegramBotClient bot, ILogger logger)
        {
            Bot = bot;
            _logger = logger;
        }

        public abstract Task<Unit> Handle(T request, CancellationToken cancellationToken);
    }
}