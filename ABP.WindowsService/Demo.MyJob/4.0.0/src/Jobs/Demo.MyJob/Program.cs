using Abp;

namespace Demo.MyJob
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bootstrapper = AbpBootstrapper.Create<MyJobAbpModule>())
            {
                bootstrapper.Initialize();
            }
        }
    }
}
