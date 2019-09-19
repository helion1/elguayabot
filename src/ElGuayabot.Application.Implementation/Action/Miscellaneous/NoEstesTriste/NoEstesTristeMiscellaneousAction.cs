using ElGuayabot.Application.Contract.Common.Context;
using ElGuayabot.Application.Contract.Model.Action.Miscellaneous;

namespace ElGuayabot.Application.Implementation.Action.Miscellaneous.NoEstesTriste
{
    public class NoEstesTristeMiscellaneousAction : MiscellaneousAction
    {
        public NoEstesTristeMiscellaneousAction(IBotContext botContext) : base(botContext)
        {
        }

        public override bool CanHandle(string condition)
        {
            return condition.ToLower().Contains("estoy triste") 
                   || condition.ToLower().Contains("I'm sad")
                   || condition.ToLower().Contains("😭") 
                   || condition.ToLower().Contains("😢") 
                   || condition.ToLower().Contains("😖") 
                   || condition.ToLower().Contains("😖") 
                   || condition.ToLower().Contains("😿")
                   || condition.ToLower().Contains("😫")
                   || condition.ToLower().Contains(":(")
                   || condition.ToLower().Contains(":-(")
                   || condition.ToLower().Contains(":'(")
                   || condition.ToLower().Contains("¡_¡");
        }
    }
}