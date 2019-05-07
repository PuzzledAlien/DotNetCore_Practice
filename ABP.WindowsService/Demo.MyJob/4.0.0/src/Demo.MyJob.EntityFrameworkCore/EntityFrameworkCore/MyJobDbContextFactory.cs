using Demo.MyJob.Configuration;
using Demo.MyJob.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Demo.MyJob.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class MyJobDbContextFactory : IDesignTimeDbContextFactory<MyJobDbContext>
    {
        public MyJobDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MyJobDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(MyJobConsts.ConnectionStringName)
            );

            return new MyJobDbContext(builder.Options);
        }
    }
}