using System.Collections.Generic;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;

namespace ElGuayabot.Domain.Chat.FindAllGroupChats
{
    public class FindAllGroupChatsQuery : Request<Result<IEnumerable<Entity.Chat>>>
    {
        
    }
}