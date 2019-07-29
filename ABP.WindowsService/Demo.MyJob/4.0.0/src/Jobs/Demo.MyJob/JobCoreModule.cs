using System;
using System.Reflection;
using Abp.Castle.Logging.Log4Net;
using Abp.Modules;
using Castle.Facilities.Logging;
using Castle.Windsor.MsDependencyInjection;
using Demo.MyJob.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Topshelf;

namespace Demo.MyJob
{
    [DependsOn(typeof(MyJobApplicationModule))]
    public class JobCoreModule : AbpModule
    {
        /// <summary>
        /// 日志配置文件路径
        /// </summary>
        public string LogConfigFile { get; set; }

        /// <summary>
        /// Windows服务的描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Windows服务的显示名称
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Windows服务的服务名称
        /// </summary>
        public string ServiceName { get; set; }

        public IConfiguration AppConfiguration { get; set; }

        public override void PreInitialize()
        {
            var host = new HostBuilder().ConfigureAppConfiguration((hostContext, configApp) =>
            {
                var hostingEnvironment = hostContext.HostingEnvironment;
                AppConfiguration = AppConfigurations.Get(hostingEnvironment.ContentRootPath, hostingEnvironment.EnvironmentName);

                AppLog4NetConfigs.AddProperty("LogsDirectory", hostingEnvironment.ContentRootPath);
                LogConfigFile = AppLog4NetConfigs.Get(hostingEnvironment.ContentRootPath, hostingEnvironment.EnvironmentName);
            }).ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton(AppConfiguration);

                WindsorRegistrationHelper.CreateServiceProvider(IocManager.IocContainer, services);
            });

            host.Build();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.IocContainer.AddFacility<LoggingFacility>(
                f => f.UseAbpLog4Net().WithConfig(LogConfigFile)
            );
            HostFactory.Run(configure =>
            {
                //定义服务描述
                configure.SetDescription(Description);
                configure.SetDisplayName(DisplayName);
                configure.SetServiceName(ServiceName);

                configure.RunAsLocalSystem();

                //使用log4net记录日志
                configure.UseLog4Net(LogConfigFile);

                //定义操作
                configure.Service<MyJobService>(service =>
                {
                    service.ConstructUsing(_ => new MyJobService());
                    service.WhenStarted(async _ => await _.StartAsync());
                    service.WhenStopped(async _ => await _.StopAsync());
                    service.WhenContinued(async _ => await _.ContinueAsync());
                    service.WhenPaused(async _ => await _.PauseAsync());
                });
            });
        }
    }
}
