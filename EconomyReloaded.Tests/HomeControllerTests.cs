using System.Collections.Generic;
using System.Web.Mvc;
using EconomyReloaded.Controllers;
using EconomyReloaded.Core.Database;
using EconomyReloaded.Core.Factory.Economy;
using EconomyReloaded.Core.Factory.User;
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

      Assert.IsNotNull(result);
      Assert.AreEqual("Index", result.ViewName);
    }

    [Test]
    public void IndexHasUserModel()
    {
      var controller = _homeController;

      var result = controller.Index() as ViewResult;

      Assert.IsNotNull(result);
      Assert.IsNotNull(result.Model);
      Assert.IsInstanceOf(typeof(IEnumerable<UserSimpleViewModel>), result.Model);
    }
  }

}
