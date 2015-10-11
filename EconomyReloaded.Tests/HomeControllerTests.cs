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
using EconomyReloaded.Core.Database;
using EconomyReloaded.Core.Factory.Economy;
using EconomyReloaded.Core.Factory.User;
using EconomyReloaded.Core.Models.User;
using EconomyReloaded.Core.Repositories.Economy;
using EconomyReloaded.Core.Repositories.User;
using EconomyReloaded.Services.Services.Economy;
using EconomyReloaded.Services.Services.User;
using EconomyReloaded.ViewModels;
using NUnit.Framework;

namespace EconomyReloaded.Tests
{
  [TestFixture]
  class HomeControllerTests
  {
    private HomeController _homeController;

    [TestFixtureSetUp]
    public void Setup()
    {
      _homeController = new HomeController(new UserService(new UserRepository(new DatabaseConnection(), new UserFactory())), new ReceiptService(new ReceiptRepository(new DatabaseConnection(), new ReceiptFactory())));
    }

    [Test]
    public void IndexReturnsView()
    {
      var controller = _homeController;

      var result = controller.Index() as ViewResult;

      Assert.AreEqual("Index", result.ViewName);
    }

    [Test]
    public void IndexHasUserModel()
    {
      var controller = _homeController;

      var result = controller.Index() as ViewResult;

      Assert.IsInstanceOf(typeof(IEnumerable<UserSimpleViewModel>), result.Model);
      Assert.IsNotNull(result.Model);
    }
  }

}
