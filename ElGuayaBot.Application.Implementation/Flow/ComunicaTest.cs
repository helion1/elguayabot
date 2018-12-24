using ElGuayaBot.Application.Contracts;
using ElGuayaBot.Application.Contracts.Flow;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ElGuayaBot.Application.Implementation.Flow
{
    public class ComunicaTest : BaseFlow, IComunicaTest
    {

        public ComunicaTest(IBotClient bot) : base(bot)
        {
        }
        public override async void Initiate(Message message)
        {

            /* El message que recibo me importa una mierda, tengo que comprobar con el getChat si el tipo de éste
             es un supergroup o un channel, y, en caso de serlo, enviar el message (que ahora si me interesa por el contenido)
             asignándole el chatId correspondiente de los grupos que tenga guardados*/
            try
            {
                string comunica = "El Guayaba COMUNICA: ";
                ChatId chatTest = -1001469899137;
                ChatId chatTest2 = -269453711;


                //var chat = await _bot.GetChatAsync(-269453711);
//                var members = await _bot.GetChat(chatTest2);
                //try
                //{
                //    var admins = _bot.GetChatAdministratorsAsync(chatTest);

                //}
                //catch (Exception)
                //{

                //    throw;
                //}

                //if (message.Chat.Type == ChatType.Channel || message.Chat.Type == ChatType.Supergroup)
                //{
                    var messageSent = await _bot.SendTextMessageAsync(
                                chatId: chatTest2,
                                text: comunica + message.Text,
                                parseMode: ParseMode.Markdown
                                );

                    var messageSentid = messageSent.MessageId;

                    PinChatComunica(messageSent);
//                }


            }
            catch (Exception)
            {

            }
        }

        public async void PinChatComunica(Message message)
        {
            try
            {
                await _bot.PinChatMessageAsync(
                        chatId: message.Chat.Id,
                        messageId: message.MessageId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
