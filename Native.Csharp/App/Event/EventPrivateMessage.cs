using Native.Csharp.App.Common;
using Native.Csharp.App.Configure;
using Native.Csharp.App.Util;
using Native.Csharp.Sdk.Cqp;
using Native.Csharp.Sdk.Cqp.EventArgs;
using Native.Csharp.Sdk.Cqp.Interface;
using System.Linq;
namespace Native.Csharp.App.Event
{
    class EventPrivateMessage : IPrivateMessage
    {
        public void PrivateMessage(object sender, CQPrivateMessageEventArgs e)
        {
            var config = WhatDidToday.Config;
            var data = WhatDidToday.Data;

            if (e.Message.OriginalMessage.StartsWith(config.PrivateCommandPrefix))
            {
                var result = data.DataDaily.FirstOrDefault(i => i.Date == Date.GetToday());
                if (result == null)
                {
                    var today = new DataDaily();
                    today.Date = Date.GetToday();
                    today.Message.Add(e.Message.OriginalMessage.Replace(config.PrivateCommandPrefix, ""));
                    data.DataDaily.Add(today);
                }
                else
                {
                    result.Message.Add(e.Message.OriginalMessage.Replace(config.PrivateCommandPrefix, ""));
                }
            }

            WhatDidToday.SaveData(AppData.CQApi.AppDirectory, data);
        }
    }
}
