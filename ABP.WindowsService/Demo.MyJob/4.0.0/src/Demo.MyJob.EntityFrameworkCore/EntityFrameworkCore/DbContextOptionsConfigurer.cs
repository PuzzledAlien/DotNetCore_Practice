using Microsoft.EntityFrameworkCore;

namespace Demo.MyJob.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<MyJobDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for MyJobDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }
    }
}
