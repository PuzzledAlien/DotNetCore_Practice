using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Demo.MyJob.EntityFrameworkCore
{
    public class MyJobDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...

        public MyJobDbContext(DbContextOptions<MyJobDbContext> options) 
            : base(options)
        {

        }
    }
}
