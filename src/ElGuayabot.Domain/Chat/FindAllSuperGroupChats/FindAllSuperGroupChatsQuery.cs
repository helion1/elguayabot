using System.Collections.Generic;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;

namespace ElGuayabot.Domain.Chat.FindAllSuperGroupChats
{
    public class FindAllSuperGroupChatsQuery : Request<Result<IEnumerable<Entity.Chat>>>
    {
        
    }
}