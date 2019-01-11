using ElGuayaBot.Application.Contracts;
using ElGuayaBot.Application.Contracts.Flow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElGuayaBot.Persistence.Contracts;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ElGuayaBot.Application.Implementation.Flow
{
    public class ComunicaTest : BaseFlow, IComunicaTest
    {
        private readonly IUnitOfWork _UnitOfWork;
        public ComunicaTest(IBotClient bot, IUnitOfWork unitOfWork) : base(bot)
        {
            _UnitOfWork = unitOfWork;
        }
        public override async void Initiate(Message message)
        {

            /* El message que recibo me importa una mierda, tengo que comprobar con el getChat si el tipo de éste
             es un supergroup o un channel, y, en caso de serlo, enviar el message (que ahora si me interesa por el contenido)
             asignándole el chatId correspondiente de los grupos que tenga guardados*/
            if (message.Text.Trim() == "")
            {
                return;
            }

            if (message.From.Id == 7089483 || message.From.Id == 42711 || message.From.Id == 489047400)
            {
                try
                {
                    var sb = new StringBuilder( "<b>El Guayaba Comunica:</b> ");
                    
                    sb.Append("<i>");
                    sb.Append(message.Text);
                    sb.Append("</i>");

                    var comunicaMessage = sb.ToString();
                
                    var groups = _UnitOfWork.GroupRepository.GetAll().Where(ch => ch.Type == "Group" || ch.Type == "Supergroup");

                    foreach (var group in groups)
                    {
                        var messageSent = await SendGuayabaComunicaMessage(group.Id, comunicaMessage);

                        if (group.Type == "Supergroup")
                        {
                            PinGuayabaComunicaMessage(messageSent);                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    //Just for Fun
                }
            }
            

        }

        private async Task<Message> SendGuayabaComunicaMessage(long chatId, string comunicaMessage)
        {
            var messageSent = await _bot.SendTextMessageAsync(
                chatId: chatId,
                text: comunicaMessage,
                parseMode: ParseMode.Html
            );

            return messageSent;
        }

        public async void PinGuayabaComunicaMessage(Message message)
        {
            try
            {
                await _bot.PinChatMessageAsync(
                        chatId: message.Chat.Id,
                        messageId: message.MessageId);
            }
            catch (Exception)
            {
                //Just for Fun
            }
        }
    }
}
