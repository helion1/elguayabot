using System.Collections.Generic;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;

namespace ElGuayabot.Domain.User.FindAllUsers
{
    public class FindAllUsersQuery : Request<Result<IEnumerable<Entity.User>>>
    {
        
    }
}