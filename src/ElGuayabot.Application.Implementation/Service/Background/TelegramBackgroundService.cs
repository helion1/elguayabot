using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Contract.Service;
using Microsoft.Extensions.DependencyInjection;

namespace ElGuayabot.Application.Implementation.Service.Background
{
    public class TelegramBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public TelegramBackgroundService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var botService = scope.ServiceProvider.GetRequiredService<ITelegramService>();
                
                botService.StartBot();
            }

            return Task.CompletedTask;
        }
    }
}