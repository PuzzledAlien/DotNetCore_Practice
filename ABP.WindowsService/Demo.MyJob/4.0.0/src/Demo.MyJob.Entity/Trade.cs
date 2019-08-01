using Abp.Domain.Entities.Auditing;

namespace Demo.MyJob.Entity
{
    public class Trade : FullAuditedEntity<long>
    {
        public string Name { get; set; }
        public string TradeUserName { get; set; }
    }
}
