using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contracts.Client;
using MediatR;
using Microsoft.Extensions.Logging;
using MihaZupan.TelegramBotClients;

namespace ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic
{
    public abstract class AbstractHandler<T>: IRequestHandler<T> where T : AbstractRequest
    {
        protected readonly BlockingTelegramBotClient Bot;

        private readonly ILogger _logger;

        protected AbstractHandler(IBotClient bot, ILogger logger)
        {
            Bot = bot.Client;

            _logger = logger;
        }

        public abstract Task<Unit> Handle(T request, CancellationToken cancellationToken);
    }
}