using System;
using Microsoft.Extensions.Hosting;

namespace ElGuayaBot.Application.Contract.Background
{
    public interface IBackgroundService: IHostedService, IDisposable
    {
    }
}