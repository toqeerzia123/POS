using System.Threading.Tasks;
using IPOC.Models.TokenAuth;
using IPOC.Web.Controllers;
using Shouldly;
using Xunit;

namespace IPOC.Web.Tests.Controllers
{
    public class HomeController_Tests: IPOCWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}