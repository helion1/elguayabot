using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Contract.Client;
using MediatR;
using Microsoft.Extensions.Logging;
using MihaZupan.TelegramBotClients;

namespace ElGuayabot.Application.Implementation.Logic.Common.AbstractLogic
{
    public abstract class AbstractHandler<T>: IRequestHandler<T> where T : AbstractRequest
    {
        protected readonly BlockingTelegramBotClient Bot;

        protected readonly ILogger<AbstractHandler<T>> Logger;

        protected AbstractHandler(IBotClient bot, ILogger<AbstractHandler<T>> logger)
        {
            Bot = bot.Client;

            Logger = logger;
        }

        public abstract Task<Unit> Handle(T request, CancellationToken cancellationToken);
    }
}