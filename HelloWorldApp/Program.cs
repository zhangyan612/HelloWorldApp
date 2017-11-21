using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWorldApi;
using HelloWorldApi.Models;
using System.Configuration;
using HelloWorldApi.Repositories;

namespace HelloWorldApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Default option set to write to console, can be modified in web.config file
            Message msg = new Message();
            msg.setMsg("Hello World");
            msg.Execute();

            // Writing to database, detail implementation still needed
            Message msg2 = new Message();
            msg2.setPlatform(new DatabaseRepository());
            msg2.setMsg("this data");
            msg2.Execute();

            Console.ReadKey();
        }
    }
}
