using Abp.Application.Services;
using Demo.MyJob.Entity.Dto;

namespace Demo.MyJob
{
    public interface IAutoMapperTestAppService : IApplicationService
    {
        OrderDto GetOrderDtoTest();
    }
}
