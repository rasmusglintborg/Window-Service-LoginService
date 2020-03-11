using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace LoginService
{
    class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x => {
                x.Service<LoginHandler>(service => {
                    service.ConstructUsing(loginHandler => new LoginHandler());
                    service.WhenStarted((loginHandler, hostControl) => loginHandler.Start(hostControl));
                    service.WhenStopped(loginHandler => loginHandler.Stop());

                });
                x.RunAsLocalSystem();
                x.SetServiceName("LoginService");
                x.SetDisplayName("Login Service(DanishBits)");
                x.SetDescription("This service logs me in on danishBit to collect juicy rewards");

            });
            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
            Console.ReadLine();
        }
    }
}

