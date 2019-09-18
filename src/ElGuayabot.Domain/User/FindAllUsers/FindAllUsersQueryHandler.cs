using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using ElGuayabot.Persistence.Contract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayabot.Domain.User.FindAllUsers
{
    internal class FindAllUsersQueryHandler : CommonHandler<FindAllUsersQuery, Result<IEnumerable<Entity.User>>>
    {
        protected readonly IUnitOfWork UnitOfWork;

        public FindAllUsersQueryHandler(ILogger<CommonHandler<FindAllUsersQuery, Result<IEnumerable<Entity.User>>>> logger, IMediator mediatR) : base(logger, mediatR)
        {
        }

        public override async Task<Result<IEnumerable<Entity.User>>> Handle(FindAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await UnitOfWork.UserRepository.GetAll();

            return Result<IEnumerable<Entity.User>>.Success(users);
        }
    }
}