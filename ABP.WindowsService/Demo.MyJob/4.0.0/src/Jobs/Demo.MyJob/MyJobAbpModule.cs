using System.Reflection;
using Abp.Modules;
using Topshelf;

namespace Demo.MyJob
{
    [DependsOn(typeof(MyJobApplicationModule))]
    public class MyJobAbpModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

        public override void PostInitialize()
        {
            HostFactory.Run(configure =>
            {
                //定义服务描述
                configure.SetDescription("Demo.MyJob Service");
                configure.SetDisplayName("Demo.MyJob");
                configure.SetServiceName("Demo.MyJob");

                configure.RunAsLocalSystem();

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
