using System;
using Microsoft.Extensions.Hosting;

namespace ElGuayabot.Application.Contract.Background
{
    public interface IBackgroundService: IHostedService, IDisposable
    {
    }
}