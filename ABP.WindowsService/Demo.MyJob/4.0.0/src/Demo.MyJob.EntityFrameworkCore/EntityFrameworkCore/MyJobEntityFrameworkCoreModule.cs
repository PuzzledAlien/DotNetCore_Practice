using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Demo.MyJob.EntityFrameworkCore
{
    [DependsOn(
        typeof(MyJobCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class MyJobEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyJobEntityFrameworkCoreModule).GetAssembly());
        }
    }
}