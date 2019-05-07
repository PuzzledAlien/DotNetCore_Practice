using System.Threading.Tasks;
using Demo.MyJob.Web.Controllers;
using Shouldly;
using Xunit;

namespace Demo.MyJob.Web.Tests.Controllers
{
    public class HomeController_Tests: MyJobWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
