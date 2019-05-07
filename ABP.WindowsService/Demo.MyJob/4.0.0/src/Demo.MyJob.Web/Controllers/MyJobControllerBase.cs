using Abp.AspNetCore.Mvc.Controllers;

namespace Demo.MyJob.Web.Controllers
{
    public abstract class MyJobControllerBase: AbpController
    {
        protected MyJobControllerBase()
        {
            LocalizationSourceName = MyJobConsts.LocalizationSourceName;
        }
    }
}