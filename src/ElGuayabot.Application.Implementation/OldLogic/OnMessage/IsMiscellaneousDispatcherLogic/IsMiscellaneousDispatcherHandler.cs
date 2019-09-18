//using System;
//using System.Threading;
//using System.Threading.Tasks;
//using ElGuayabot.Application.Contract.Client;
//using ElGuayabot.Application.Implementation.Logic.Command.SavageLogic;
//using ElGuayabot.Application.Implementation.Logic.Common.AbstractLogic;
//using ElGuayabot.Application.Implementation.Logic.Miscellaneous.AlFinalMeMosqueoLogic;
//using ElGuayabot.Application.Implementation.Logic.Miscellaneous.ButGoldLogic;
//using ElGuayabot.Application.Implementation.Logic.Miscellaneous.CallateLaJetaLogic;
//using ElGuayabot.Application.Implementation.Logic.Miscellaneous.ColdMeatLogic;
//using ElGuayabot.Application.Implementation.Logic.Miscellaneous.FiambreLogic;
//using ElGuayabot.Application.Implementation.Logic.Miscellaneous.MalditoGuayabaLogic;
//using ElGuayabot.Application.Implementation.Logic.Miscellaneous.NacionalidadLogic;
//using ElGuayabot.Application.Implementation.Logic.Miscellaneous.NoEstesTristeLogic;
//using MediatR;
//using Microsoft.Extensions.Logging;
//using NeoSmart.Unicode;
//
//namespace ElGuayabot.Application.Implementation.Logic.OnMessage.IsMiscellaneousDispatcherLogic
//{
//    public class IsMiscellaneousDispatcherHandler : AbstractHandler<IsMiscellaneousDispatcherRequest>
//    {
//        private readonly IMediator _mediatR;
//
//        public IsMiscellaneousDispatcherHandler(IBotClient bot, ILogger<AbstractHandler<IsMiscellaneousDispatcherRequest>> logger, IMediator mediatR) : base(bot, logger)
//        {
//            _mediatR = mediatR;
//        }
//
//        public override async Task<Unit> Handle(IsMiscellaneousDispatcherRequest request, CancellationToken cancellationToken)
//        {
//            var message = request.Message;
//
//            var text = message.Text;
//            
//            if (IsAllUpper(text) && text != "OMG" && text != "LMAO" && text != "F" && text != "WTF" && text != "LOL")
//            {
//                await _mediatR.Send(new CallateLaJetaRequest { Message = message }, cancellationToken);
//            }
//            else if (text.ToLower().Contains("al final me mosqueo"))
//            {
//                await _mediatR.Send(new AlFinalMeMosqueoRequest { Message = message }, cancellationToken);
//            } 
//            else if (text.ToLower().Contains("nacionalidad"))
//            {
//                await _mediatR.Send(new NacionalidadRequest { Message = message }, cancellationToken);
//            } 
//            else if (NoEstesTristeTrigger(text))
//            {
//                await _mediatR.Send(new NoEstesTristeRequest { Message = message }, cancellationToken);
//            } 
//            else if (text.ToLower().Equals("old"))
//            {
//                await _mediatR.Send(new ButGoldRequest { Message = message }, cancellationToken);
//            }
//            else if(text.ToLower().Contains("tengo hambre") && !text.ToLower().Contains("no tengo hambre"))
//            {
//                await _mediatR.Send(new FiambreRequest { Message = message }, cancellationToken);
//            }
//            else if(text.ToLower().Contains("i'm hungry"))
//            {
//                await _mediatR.Send(new ColdMeatRequest { Message = message }, cancellationToken);
//            }
//            else if(message.Text.ToLower().Contains("maldito guayaba") || message.Text.ToLower().Contains("bendito guayaba"))
//            {
//                await _mediatR.Send(new MalditoGuayabaRequest { Message = message }, cancellationToken);
//            }
//            else if (message.Text.ToLower().Contains("😂😂😂😂😂😂😂😂😂😂"))
//            {
//                await _mediatR.Send(new SavageRequest {Message = message}, cancellationToken);
//            }
//
//            return Unit.Value;
//        }
//        
//        private bool IsAllUpper(string input)
//        {
//            var containsLetters = false;
//            if (Emoji.IsEmoji((input)))
//            {
//                return false;
//            }
//
//            for (int i = 0; i < input.Length; i++)
//            {
//                if (Char.IsLetter(input[i]))
//                {
//                    containsLetters = true;
//                }
//            }
//            
//            for (int i = 0; i < input.Length; i++)
//            {
//                if (Char.IsLetter(input[i]) && !Char.IsUpper(input[i]))
//                    return false;
//            }
//            
//            return containsLetters;
//        }
//
//        private bool NoEstesTristeTrigger(string text)
//        {
//            return text.ToLower().Contains("😭") 
//                   || text.ToLower().Contains("😢") 
//                   || text.ToLower().Contains("😖") 
//                   || text.ToLower().Contains("😖") 
//                   || text.ToLower().Contains("😿")
//                   || text.ToLower().Contains("😫")
//                   || text.ToLower().Contains(":(")
//                   || text.ToLower().Contains(":-(")
//                   || text.ToLower().Contains(":'(")
//                   || text.ToLower().Contains("¡_¡");
//        }
//    }
//}