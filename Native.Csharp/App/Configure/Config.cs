namespace Native.Csharp.App.Configure
{
    class Config
    {
        public string CreatorName { get; set; } = "%Name%";
        public long CreatorQQ { get; set; } = 123456789;
        public string PrivateCommandPrefix { get; set; } = "我今天做了";
        public string GroupCommandQuery { get; set; } = "%Name%%Date%做什么";
        public string GroupCommandUrge { get; set; } = "%Name%不要咕咕咕！";
        public string GroupQueryPrefix { get; set; } = "%Name%今天做了：";
        public string GroupQueryNull { get; set; } = "%Name%%Date%什么也没做！";
        public string PrivateUrge { get; set; } = "%Name%不要咕咕咕！";
    }
}
