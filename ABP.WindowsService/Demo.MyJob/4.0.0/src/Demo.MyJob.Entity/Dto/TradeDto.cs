using Abp.Application.Services.Dto;

namespace Demo.MyJob.Entity.Dto
{
    public class TradeDto : FullAuditedEntityDto<string>
    {
        public string Name { get; set; }
        public string TradeUserName { get; set; }
    }
}
