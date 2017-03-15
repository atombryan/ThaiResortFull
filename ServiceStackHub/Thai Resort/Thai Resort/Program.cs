using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mono.Unix;
using Mono.Unix.Native;
using ServiceStack;
using System.Net.NetworkInformation;

namespace Thai_Resort
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter in the desired listening URI");
            var enteredURI = "http://192.168.1.125:4915/";
            var appHost = new Global.ThaiResortAppHostSelfHost()
                .Init()
                .Start(enteredURI);

            Console.WriteLine("Started at {0}, listening on {1}", DateTime.Now, enteredURI);
            bool quit = false;
            while (!quit)
            {
                if (Console.ReadLine().Equals("quit")) quit = true;
            }
        }
    }
}