using System;
using System.Threading.Tasks;
using Abp.Logging;
using Quartz;

namespace Demo.MyJob.Jobs
{
    class SayHelloJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            LogHelper.Logger.Info(nameof(SayHelloJob));
            await Task.Run(() =>
            {
                Console.WriteLine("Hello World to Async!");
            });
            Console.WriteLine("Hello World!");
        }
    }
}
