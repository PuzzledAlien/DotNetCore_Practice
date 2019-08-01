using System;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Logging;
using Newtonsoft.Json;
using Quartz;

namespace Demo.MyJob.Jobs
{
    class SayHelloJob : IJob
    {
        private readonly IAutoMapperTestAppService _autoMapperTestAppService;
        public SayHelloJob()
        {
            _autoMapperTestAppService = IocManager.Instance.Resolve<IAutoMapperTestAppService>();
        }
        public async Task Execute(IJobExecutionContext context)
        {
            LogHelper.Logger.Info(nameof(SayHelloJob));

            var orderDto = _autoMapperTestAppService.GetOrderDtoTest();
            Console.WriteLine("{0}", JsonConvert.SerializeObject(orderDto));

            await Task.Run(() =>
            {
                Console.WriteLine("Hello World to Async!");
            });
            Console.WriteLine("Hello World!");
        }
    }
}
