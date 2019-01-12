using System.Threading;
using System.Threading.Tasks;
using ElGuayaBot.Application.Contracts.Service;
using Microsoft.Extensions.DependencyInjection;

namespace ElGuayaBot.Application.Implementation.Background
{
    public class TelegramBotBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public TelegramBotBackgroundService(IServiceScopeFactory serviceScopeFactory) : base()
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var botService = scope.ServiceProvider.GetRequiredService<IBotService>();
                
                botService.FundarRepublica();
            }

            return Task.CompletedTask;
        }
    }
}