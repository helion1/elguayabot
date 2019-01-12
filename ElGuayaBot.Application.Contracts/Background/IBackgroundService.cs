using System;
using Microsoft.Extensions.Hosting;

namespace ElGuayaBot.Application.Contracts.Background
{
    public interface IBackgroundService: IHostedService, IDisposable
    {
    }
}