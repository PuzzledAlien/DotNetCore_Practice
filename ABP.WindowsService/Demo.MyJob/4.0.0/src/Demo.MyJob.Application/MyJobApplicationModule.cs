using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Demo.MyJob
{
    [DependsOn(
        typeof(MyJobCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MyJobApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyJobApplicationModule).GetAssembly());
        }
    }
}