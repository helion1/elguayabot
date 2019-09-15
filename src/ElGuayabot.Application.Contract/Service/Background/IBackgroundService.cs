using System;
using Microsoft.Extensions.Hosting;

namespace ElGuayabot.Application.Contract.Service.Background
{
    public interface IBackgroundService: IHostedService, IDisposable
    {
    }
}