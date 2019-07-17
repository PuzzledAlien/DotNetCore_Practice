using Abp.AspNetCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace WebApplication1
{
    [DependsOn(typeof(AbpAspNetCoreModule))]
    public class WebApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WebApplicationModule).GetAssembly());
        }
    }
}
