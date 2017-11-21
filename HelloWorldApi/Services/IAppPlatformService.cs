using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorldApi.Services
{
    public interface IAppPlatformService
    {
        void Set(string message);
        string Get();
        void Execute();
    }
}