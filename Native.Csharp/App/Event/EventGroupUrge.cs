using Native.Csharp.App.Common;
using Native.Csharp.Sdk.Cqp.EventArgs;
using Native.Csharp.Sdk.Cqp.Interface;

namespace Native.Csharp.App.Event
{
    class EventGroupUrge : IGroupMessage
    {
        public void GroupMessage(object sender, CQGroupMessageEventArgs e)
        {
            var config = WhatDidToday.Config;
            var commandUrge = config.GroupCommandUrge.Replace("%Name%", config.CreatorName);
            var qq = config.CreatorQQ;

            if (e.Message.OriginalMessage == commandUrge)
            {
                AppData.CQApi.SendPrivateMessage(qq, config.PrivateUrge.Replace("%Name%", config.CreatorName));
            }
        }
    }
}
