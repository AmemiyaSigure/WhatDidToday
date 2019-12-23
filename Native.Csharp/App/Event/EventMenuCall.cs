using Native.Csharp.App.Menu;
using Native.Csharp.Sdk.Cqp.EventArgs;
using Native.Csharp.Sdk.Cqp.Interface;
using System.Windows.Forms;

namespace Native.Csharp.App.Event
{
    class EventMenuCall : IMenuCall
    {
        public void MenuCall(object sender, CQMenuCallEventArgs e)
        {
            // Todo
            MessageBox.Show("这个功能还没有开发完成哦！");
            /*
            var menuSettings = new MenuSettings();
            menuSettings.Show();
            */
        }
    }
}
