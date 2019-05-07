using Abp.Application.Services;

namespace Demo.MyJob
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class MyJobAppServiceBase : ApplicationService
    {
        protected MyJobAppServiceBase()
        {
            LocalizationSourceName = MyJobConsts.LocalizationSourceName;
        }
    }
}