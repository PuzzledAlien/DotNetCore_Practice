using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Demo.MyJob.Web.Startup;
namespace Demo.MyJob.Web.Tests
{
    [DependsOn(
        typeof(MyJobWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class MyJobWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyJobWebTestModule).GetAssembly());
        }
    }
}