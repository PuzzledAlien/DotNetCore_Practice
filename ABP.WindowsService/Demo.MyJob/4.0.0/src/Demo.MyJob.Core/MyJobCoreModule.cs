using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Demo.MyJob.Localization;

namespace Demo.MyJob
{
    [DependsOn(typeof(AbpAutoMapperModule))]
    public class MyJobCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            MyJobLocalizationConfigurer.Configure(Configuration.Localization);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
            {
                config.AddMaps(typeof(MyJobCoreModule));
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyJobCoreModule).GetAssembly());
        }
    }
}