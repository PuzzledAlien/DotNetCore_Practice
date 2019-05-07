using Abp.Modules;
using Abp.Reflection.Extensions;
using Demo.MyJob.Localization;

namespace Demo.MyJob
{
    public class MyJobCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            MyJobLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyJobCoreModule).GetAssembly());
        }
    }
}