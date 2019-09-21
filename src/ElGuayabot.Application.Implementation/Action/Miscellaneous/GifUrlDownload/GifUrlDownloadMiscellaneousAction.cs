using System;
using ElGuayabot.Application.Contract.Common.Context;
using ElGuayabot.Application.Contract.Model.Action.Miscellaneous;

namespace ElGuayabot.Application.Implementation.Action.Miscellaneous.GifUrlDownload
{
    public class GifUrlDownloadMiscellaneousAction : MiscellaneousAction
    {
        public GifUrlDownloadMiscellaneousAction(IBotContext botContext) : base(botContext)
        {
        }

        public override bool CanHandle(string condition)
        {
            return condition.ToLower().Contains(".gif");
        }
    }
}