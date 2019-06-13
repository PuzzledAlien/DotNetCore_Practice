using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace Demo.MyJob
{
    public class MyJobService
    {
        private readonly Task<IScheduler> _defaultScheduler;
        private static IScheduler _scheduler;
        public MyJobService()
        {
            _defaultScheduler = StdSchedulerFactory.GetDefaultScheduler();
        }
        public async Task StartAsync()
        {
            _scheduler = await _defaultScheduler;
            await _scheduler.Start();
        }

        public async Task StopAsync()
        {
            await _scheduler.Shutdown();
        }

        public async Task ContinueAsync()
        {
            await _scheduler.ResumeAll();
        }

        public async Task PauseAsync()
        {
            await _scheduler.PauseAll();
        }
    }
}
