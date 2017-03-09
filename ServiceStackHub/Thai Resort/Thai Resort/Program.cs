using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mono.Unix;
using Mono.Unix.Native;


namespace Thai_Resort
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Initialize app host
            var appHost = new Global.ThaiResortAppHost();
            appHost.Init();
            appHost.Start("http://127.0.0.1:8080/");

            UnixSignal[] signals = new UnixSignal[] {
                new UnixSignal(Signum.SIGINT),
                new UnixSignal(Signum.SIGTERM),
            };

            // Wait for a unix signal
            for (bool exit = false; !exit;)
            {
                int id = UnixSignal.WaitAny(signals);

                if (id >= 0 && id < signals.Length)
                {
                    if (signals[id].IsSet) exit = true;
                }
            }
        }
    }
}