using HelloWorldApi.Services;
using System;

namespace HelloWorldApi.Repositories
{
    public class DatabaseRepository : IAppPlatformService
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
            // implement database logic to save to db
            Console.WriteLine("Message:" + Message + " will be saved to db");
        }
    }
}