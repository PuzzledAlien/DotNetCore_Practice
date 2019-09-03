using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Demo.MyJob.Configuration;
using Demo.MyJob.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Demo.MyJob.Web.Startup
{
    [DependsOn(
        typeof(MyJobApplicationModule), 
        typeof(MyJobEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class MyJobWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public MyJobWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabled = false;

            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(MyJobConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<MyJobNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(MyJobApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyJobWebModule).GetAssembly());
        }
    }
}