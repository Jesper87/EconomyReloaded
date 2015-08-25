using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using EconomyReloaded.Controllers;
using EconomyReloaded.Core.Models.User;
using EconomyReloaded.Core.Repositories.User;
using EconomyReloaded.Services.Services.User;
using NUnit.Framework;

namespace EconomyReloaded.Tests
{
    [TestFixture]
    class HomeControllerTests
    {
        [Test]
        public void IndexReturnsView()
        {
            var controller = GetHomeControler(new FakeUserService());

            var result = controller.Index() as ViewResult;

            Assert.AreEqual("Index",result.ViewName);
        }

        [Test]
        public void IndexHasUserModel()
        {
            var controller = GetHomeControler(new FakeUserService());

            var result = controller.Index() as ViewResult;

            Assert.IsAssignableFrom(typeof(List<UserDetails>), result.Model);
            Assert.IsNotNull(result.Model);
        }


        private static HomeController GetHomeControler(IUserService userService)
        {
            HomeController homeController = new HomeController(userService);

            homeController.ControllerContext = new ControllerContext
            {
                Controller = homeController,
                RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
            };

            return homeController;
        }

        private class MockHttpContext : HttpContextBase
        {
            private readonly IPrincipal _user = new GenericPrincipal(new GenericIdentity("someUser"), null);

            public override IPrincipal User
            {
                get
                {
                    return _user;
                }
                set { base.User = value; }
            }
        }
    }

}
