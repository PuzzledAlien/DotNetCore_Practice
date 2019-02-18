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
                //注入IConfiguration到DI容器
                services.AddSingleton(_appConfiguration);

                //注入MyService到DI容器
                services.AddSingleton<IMyService, MyService>();
            });

            //初始化通用主机
            var host = hostBuilder.Build();

            //获取MyService
            var myService = host.Services.GetService<IMyService>();

            //调用SayMyWords方法
            myService.SayMyWords();

            Console.ReadKey();
        }
    }
}
