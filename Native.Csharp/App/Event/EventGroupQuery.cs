using System.Linq;
using Native.Csharp.App.Util;
using Native.Csharp.Sdk.Cqp.EventArgs;
using Native.Csharp.Sdk.Cqp.Interface;

namespace Native.Csharp.App.Event
{
    class EventGroupQuery : IGroupMessage
    {
        public void GroupMessage(object sender, CQGroupMessageEventArgs e)
        {
            var config = WhatDidToday.Config;
            var data = WhatDidToday.Data.DataDaily;
            var commandBeforeYesterday = config.GroupCommandQuery.Replace("%Name%", config.CreatorName).Replace("%Date%", "前天");
            var commandYesterday = config.GroupCommandQuery.Replace("%Name%", config.CreatorName).Replace("%Date%", "昨天");
            var commandToday = config.GroupCommandQuery.Replace("%Name%", config.CreatorName).Replace("%Date%", "今天");

            var msg = e.Message.OriginalMessage;

            if (msg == commandToday)
            {
                var result = data.FirstOrDefault(i => i.Date == Date.GetToday());
                if (result == null)
                {
                    e.FromGroup.SendGroupMessage(config.GroupQueryNull.Replace("%Name%", config.CreatorName).Replace("%Date%", "今天"));
                }
                else
                {
                    e.FromGroup.SendGroupMessage(config.GroupQueryPrefix.Replace("%Name%", config.CreatorName), result.Message.ToArray());
                }
            }
            else if (msg == commandYesterday)
            {
                var result = data.FirstOrDefault(i => i.Date == Date.GetYesterday());
                if (result == null)
                {
                    e.FromGroup.SendGroupMessage(config.GroupQueryNull.Replace("%Name%", config.CreatorName).Replace("%Date%", "昨天"));
                }
                else
                {
                    e.FromGroup.SendGroupMessage(config.GroupQueryPrefix.Replace("%Name%", config.CreatorName), result.Message.ToArray());
                }
            }
            else if (msg == commandBeforeYesterday)
            {
                var result = data.FirstOrDefault(i => i.Date == Date.GetBeforeYesterday());
                if (result == null)
                {
                    e.FromGroup.SendGroupMessage(config.GroupQueryNull.Replace("%Name%", config.CreatorName).Replace("%Date%", "前天"));
                }
                else
                {
                    e.FromGroup.SendGroupMessage(config.GroupQueryPrefix.Replace("%Name%", config.CreatorName), result.Message.ToArray());
                }
            }
        }
    }
}
