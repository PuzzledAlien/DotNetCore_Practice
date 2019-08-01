using Abp.ObjectMapping;
using Demo.MyJob.Entity;
using Demo.MyJob.Entity.Dto;

namespace Demo.MyJob
{
    public class AutoMapperTestAppService : MyJobAppServiceBase, IAutoMapperTestAppService
    {
        private readonly IObjectMapper _objectMapper;
        public AutoMapperTestAppService(IObjectMapper objectMapper)
        {
            _objectMapper = objectMapper;
        }

        public OrderDto GetOrderDtoTest()
        {
            var order = new Order
            {
                OrderName = "测试",
                PhoneNumber = "11111111111"
            };

            var orderDto = _objectMapper.Map<OrderDto>(order);

            return orderDto;
        }
    }
}
