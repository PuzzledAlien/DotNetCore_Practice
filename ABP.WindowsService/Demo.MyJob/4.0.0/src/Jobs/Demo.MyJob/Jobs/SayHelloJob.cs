using System;
using System.Threading.Tasks;
using Quartz;

namespace Demo.MyJob.Jobs
{
    class SayHelloJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
