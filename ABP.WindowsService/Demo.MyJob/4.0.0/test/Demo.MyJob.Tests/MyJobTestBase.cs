using System;
using System.Threading.Tasks;
using Abp.TestBase;
using Demo.MyJob.EntityFrameworkCore;
using Demo.MyJob.Tests.TestDatas;

namespace Demo.MyJob.Tests
{
    public class MyJobTestBase : AbpIntegratedTestBase<MyJobTestModule>
    {
        public MyJobTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<MyJobDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<MyJobDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<MyJobDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<MyJobDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<MyJobDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<MyJobDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<MyJobDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<MyJobDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
