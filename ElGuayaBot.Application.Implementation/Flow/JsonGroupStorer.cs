using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types;
using Newtonsoft.Json;

namespace ElGuayaBot.Application.Implementation.Flow
{
    public class JsonGroupStorer
    {
        public async void storeGroupId(Message message)
        {
            string arrayRootName = "ChatGroups";
            string title = message.Chat.Title;
            long chatId = message.Chat.Id;

        }

    }
}
