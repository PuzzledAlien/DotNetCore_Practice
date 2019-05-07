using Abp.AspNetCore.Mvc.Views;

namespace Demo.MyJob.Web.Views
{
    public abstract class MyJobRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected MyJobRazorPage()
        {
            LocalizationSourceName = MyJobConsts.LocalizationSourceName;
        }
    }
}
