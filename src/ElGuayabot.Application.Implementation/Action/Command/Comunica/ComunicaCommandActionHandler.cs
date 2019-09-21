using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Implementation.Common.Response.TextToChat;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using ElGuayabot.Domain.Chat.FindAllGroupChats;
using ElGuayabot.Domain.Chat.FindAllSuperGroupChats;
using ElGuayabot.Domain.Entity;
using MediatR;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types.Enums;

namespace ElGuayabot.Application.Implementation.Action.Command.Comunica
{
    public class ComunicaCommandActionHandler : CommonHandler<ComunicaCommandAction, Result>
    {
        public ComunicaCommandActionHandler(ILogger<CommonHandler<ComunicaCommandAction, Result>> logger, IMediator mediatR) : base(logger, mediatR)
        {
        }

        public override async Task<Result> Handle(ComunicaCommandAction request, CancellationToken cancellationToken)
        {
            var restOfText = request.Text.Substring(request.Text.IndexOf(' ') + 1);

            if (restOfText == request.Text || restOfText.Trim() == "" )
            {
                return Result.Success();
            }
            var sb = new StringBuilder( "<b>El Guayaba Comunica:</b> ");
                    
            sb.Append("<i>");
            sb.Append(restOfText);
            sb.Append("</i>");

            var comunicaMessage = sb.ToString();

            var groupsResult = await MediatR.Send(new FindAllGroupChatsQuery(), cancellationToken);
            var superGroupsResult = await MediatR.Send(new FindAllSuperGroupChatsQuery(), cancellationToken);

            if (groupsResult.Succeeded && superGroupsResult.Succeeded)
            {
                var chats = groupsResult.Value.ToList();
                
                chats.AddRange(superGroupsResult.Value);
                
                foreach (var chat in chats)
                {
                    var messageSent = await MediatR.Send(new TextToChatResponse(comunicaMessage, chat.Id, ParseMode.Html), cancellationToken);

                    if (messageSent.Succeeded && chat.Type == Chat.ChatType.Supergroup)
                    {
                        //TODO PIN THE MESSAGE.
                    }
                }
            }
            
            return Result.Success();
        }
    }
}