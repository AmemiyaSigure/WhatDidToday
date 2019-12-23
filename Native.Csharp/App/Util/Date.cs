using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Util
{
    class Date
    {
        public static string GetBeforeYesterday()
        {
            return DateTime.Now.AddDays(-2).ToString("yyyyMMdd");
        }

        public static string GetYesterday()
        {
            return DateTime.Now.AddDays(-1).ToString("yyyyMMdd");
        }

        public static string GetToday()
        {
            return DateTime.Now.ToString("yyyyMMdd");
        }
    }
}
