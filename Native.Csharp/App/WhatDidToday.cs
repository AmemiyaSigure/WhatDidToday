using Native.Csharp.App.Configure;
using Newtonsoft.Json;
using System.IO;

namespace Native.Csharp.App
{
    class WhatDidToday
    {
        public static readonly string Name = "今天做什么";
        public static readonly string Author = "雨宫时雨";
        public static readonly string Version = "1.0.0";

        public static Config Config { get; private set; }
        public static Data Data { get; private set; }

        public static void LoadConfig(string path)
        {
            var content = InternalLoad("config.json", path);
            if (content == "")
            {
                SaveData(path, new Data());
            }
            else
            {
                Config = JsonConvert.DeserializeObject<Config>(content);
            }
        }

        public static void LoadData(string path)
        {
            var content = InternalLoad("data.json", path);
            if (content == "")
            {
                SaveData(path, new Data());
            }
            else
            {
                Data = JsonConvert.DeserializeObject<Data>(content);
            }
        }

        public static void SaveConfig(string path, Config newConfig)
        {
            InternalSave("config.json", path, JsonConvert.SerializeObject(newConfig));
            Config = newConfig;
        }

        public static void SaveData(string path, Data newData)
        {
            InternalSave("data.json", path, JsonConvert.SerializeObject(newData));
            Data = newData;
        }

        private static string InternalLoad(string name, string path)
        {
            var filePath = path + name;
            if (!File.Exists(filePath))
            {
                return "";
            }
            return File.ReadAllText(filePath);
        }

        private static void InternalSave(string name, string path, string content)
        {
            var filePath = path + name;
            File.WriteAllText(filePath, content);
        }
    }
}
