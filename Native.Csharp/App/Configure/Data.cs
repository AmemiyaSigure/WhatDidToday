using System;
using System.Collections.Generic;

namespace Native.Csharp.App.Configure
{
    class Data
    {
        public List<DataDaily> DataDaily { get; set; } = new List<DataDaily>();

        internal object FirstOrDefault(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }

    class DataDaily
    {
        public string Date { get; set; }
        public List<string> Message { get; set; } = new List<string>();
    }
}
