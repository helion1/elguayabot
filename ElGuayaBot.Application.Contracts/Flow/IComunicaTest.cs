using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types;


namespace ElGuayaBot.Application.Contracts.Flow
{
    public interface IComunicaTest : IBaseFlow
    {
        void PinGuayabaComunicaMessage(Message message);
    }
}
