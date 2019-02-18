using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleApp1
{
    class Program
    {
        private static IConfiguration _appConfiguration;
        static void Main(string[] args)
        {
            var hostBuilder = new HostBuilder().ConfigureAppConfiguration((hostContext, configApp) =>
            {
                var hostingEnvironment = hostContext.HostingEnvironment;
                _appConfiguration = AppConfigurations.Get(hostingEnvironment.ContentRootPath, hostingEnvironment.EnvironmentName);
            }).ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton(_appConfiguration);

                services.AddSingleton<IMyService, MyService>();
            });

            var host = hostBuilder.Build();

            var myService = host.Services.GetService<IMyService>();

            myService.SayMyWords();

            Console.ReadKey();
        }
    }
}
