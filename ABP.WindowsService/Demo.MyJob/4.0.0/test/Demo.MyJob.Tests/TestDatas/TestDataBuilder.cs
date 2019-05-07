using Demo.MyJob.EntityFrameworkCore;

namespace Demo.MyJob.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly MyJobDbContext _context;

        public TestDataBuilder(MyJobDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}