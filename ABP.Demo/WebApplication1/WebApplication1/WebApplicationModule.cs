using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Web.Models;

namespace WebApplication1
{
    [DependsOn(typeof(AbpAspNetCoreModule))]
    public class WebApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            var result = new DontWrapResultAttribute();
            Configuration.Modules.AbpAspNetCore().DefaultWrapResultAttribute.WrapOnError = result.WrapOnError;
            Configuration.Modules.AbpAspNetCore().DefaultWrapResultAttribute.WrapOnSuccess = result.WrapOnSuccess;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WebApplicationModule).GetAssembly());
        }
    }
}
