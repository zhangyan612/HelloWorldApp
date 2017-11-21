using System;
using HelloWorldApi.Services;
using System.Configuration;
using HelloWorldApi.Repositories;

namespace HelloWorldApi.Models
{
    public class Message
    {
        public string text { get; set; }
        IAppPlatformService platform;

        public Message()
        {
            var config = ConfigurationManager.AppSettings["TargetPlatform"];

            switch (config)
            {
                case "Console":
                    this.platform = new ConsoleRepository();
                    return;
                case "Database":
                    this.platform = new DatabaseRepository();
                    return;
                default:
                    this.platform = new ConsoleRepository();
                    return;
            }
        }

        public void setPlatform(IAppPlatformService platform)
        {
            this.platform = platform;
        }

        public IAppPlatformService getPlatform()
        {
            return platform;
        }

        public void setMsg(string message)
        {
            this.text = message;
            platform.Set(message);
        }

        public string getMsg()
        {
            return platform.Get();
        }

        public void Execute()
        {
            platform.Execute();
        }
    }
}