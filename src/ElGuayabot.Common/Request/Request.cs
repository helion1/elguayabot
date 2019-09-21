using System;
using MediatR;

namespace ElGuayabot.Common.Request
{
    public abstract class Request<T> : IRequest<T>
    {
        public DateTime Timestamp { get; }
        
        protected Request()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}