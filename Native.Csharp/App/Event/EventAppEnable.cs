using System;
using Native.Csharp.App.Common;
using Native.Csharp.Sdk.Cqp.EventArgs;
using Native.Csharp.Sdk.Cqp.Interface;

namespace Native.Csharp.App.Event
{
    class EventAppEnable : IAppEnable
    {
        public void AppEnable(object sender, CQAppEnableEventArgs e)
        {
            AppData.CQLog.Info("欢迎使用！");
            AppData.CQLog.Info("正在加载配置文件和数据文件。");

            try
            {
                WhatDidToday.LoadConfig(AppData.CQApi.AppDirectory);
                WhatDidToday.LoadData(AppData.CQApi.AppDirectory);
            }
            catch (Exception ex)
            {
                AppData.CQLog.Fatal(ex.ToString());
                throw;
            }
        }
    }
}
