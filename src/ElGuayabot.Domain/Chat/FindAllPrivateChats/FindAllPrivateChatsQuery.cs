using System.Collections.Generic;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;

namespace ElGuayabot.Domain.Chat.FindAllPrivateChats
{
    public class FindAllPrivateChatsQuery : Request<Result<IEnumerable<Entity.Chat>>>
    {
        
    }
}