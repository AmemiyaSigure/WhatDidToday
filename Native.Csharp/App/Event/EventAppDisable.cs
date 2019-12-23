using Native.Csharp.App.Common;
using Native.Csharp.Sdk.Cqp.EventArgs;
using Native.Csharp.Sdk.Cqp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Event
{
    class EventAppDisable : IAppDisable
    {
        public void AppDisable(object sender, CQAppDisableEventArgs e)
        {
            AppData.CQLog.Info("感谢使用！");
            AppData.CQLog.Info("正在保存配置文件和数据文件。");

            try
            {
                WhatDidToday.SaveConfig(AppData.CQApi.AppDirectory, WhatDidToday.Config);
                WhatDidToday.SaveData(AppData.CQApi.AppDirectory, WhatDidToday.Data);
            }
            catch (Exception ex)
            {
                AppData.CQLog.Fatal(ex.ToString());
                throw;
            }
        }
    }
}
