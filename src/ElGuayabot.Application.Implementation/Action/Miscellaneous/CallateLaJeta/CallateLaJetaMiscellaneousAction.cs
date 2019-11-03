using System;
using ElGuayabot.Application.Contract.Common.Context;
using ElGuayabot.Application.Contract.Model.Action.Miscellaneous;
using ElGuayabot.Application.Implementation.Common.Context;
using ElGuayabot.Common.Request;
using NeoSmart.Unicode;

namespace ElGuayabot.Application.Implementation.Action.Miscellaneous.CallateLaJeta
{
    public class CallateLaJetaMiscellaneousAction : MiscellaneousAction
    {
        public DateTime TimeStamp { get; set; }
        
        public CallateLaJetaMiscellaneousAction(IBotContext botContext) : base(botContext)
        {
            TimeStamp = botContext.Message.Date;
        }

        public override bool CanHandle(string condition)
        {
            return IsAllUpper(condition) 
                    && condition != "OMG" 
                    && condition != "OMFG" 
                    && condition != "LMAO"
                    && condition != "LMAOO" 
                    && condition != "WTF" 
                    && condition != "LOL"
                    && condition.Length > 2
                    && TimeStamp.Millisecond % 2 == 0;
        }
        
        private bool IsAllUpper(string input)
        {
            var containsLetters = false;
            if (Emoji.IsEmoji((input)))
            {
                return false;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsLetter(input[i]))
                {
                    containsLetters = true;
                }
            }
            
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsLetter(input[i]) && !Char.IsUpper(input[i]))
                    return false;
            }
            
            return containsLetters;
        }
    }
}