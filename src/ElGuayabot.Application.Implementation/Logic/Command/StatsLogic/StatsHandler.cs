using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Contract.Client;
using ElGuayabot.Application.Contract.Service;
using ElGuayaBot.Application.Implementation.Logic.Common.AbstractLogic;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ElGuayaBot.Application.Implementation.Logic.Command.StatsLogic
{
    public class StatsHandler : AbstractHandler<StatsRequest>
    {
        private readonly IChatService _chatService;
        
        private readonly IUserService _userService;

        public StatsHandler(IBotClient bot, ILogger<AbstractHandler<StatsRequest>> logger, IChatService chatService, IUserService userService) : base(bot, logger)
        {
            _chatService = chatService;
            _userService = userService;
        }

        public override async Task<Unit> Handle(StatsRequest request, CancellationToken cancellationToken)
        {
            var message = request.Message;

            if (!UserHasRights(message) || message.Chat.Type != ChatType.Private)
            {
                return Unit.Value;
            }
            
            var groupChatsCount = _chatService.GetGroupChats().Count();
            var supergroupChatsCount = _chatService.GetSupergroupChats().Count();
            var privateChatsCount = _chatService.GetPrivateChats().Count();

            var usersCount = _userService.GetAll().Count();
            
            var sb = new StringBuilder();
            sb.AppendLine("<b>ElGuayaBot</b> stats & Info:");
            sb.AppendLine();
            sb.AppendLine($"👱‍♂️ {usersCount} <i>users</i>");
            sb.AppendLine($"👬 {privateChatsCount} <i>private</i> chats");
            sb.AppendLine($"👨‍👨‍👦 {groupChatsCount} <i>group</i> chats");
            sb.AppendLine($"👨‍👨‍👦‍👦️ {supergroupChatsCount} <i>supergroups</i> chats");

            var response = sb.ToString();
            
            
            await Bot.SendTextMessageAsync(
                chatId: message.Chat.Id, 
                text: response,
                parseMode: ParseMode.Html, 
                cancellationToken: cancellationToken);
            
            return Unit.Value;
        }
        
        private bool UserHasRights(Message message)
        {
            //TODO: Move this to config/resource file
            var usersWithRights = new List<int>
            {
                489047400, // ElGuayaba
                7089483, // Elementh
                42711 // Zabrios
            };

            return usersWithRights.Contains(message.From.Id);
        }
    }
}