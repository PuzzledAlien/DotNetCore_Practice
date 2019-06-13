using System;
using System.Threading.Tasks;
using Quartz;

namespace Demo.MyJob.Jobs
{
    class SayHelloJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Hello World to Async!");
            });
            Console.WriteLine("Hello World!");
        }
    }
}
