using HelloWorldApi.Services;
using System;

namespace HelloWorldApi.Repositories
{
    public class ConsoleRepository : IAppPlatformService
    {
        public string Message;

        public void Set(string message)
        {
            this.Message = message;
        }
        public string Get()
        {
            return this.Message;
        }
        public void Execute()
        {
            Console.WriteLine(Message);
        }
    }
}