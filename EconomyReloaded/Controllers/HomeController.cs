using System.Linq;
using System.Web.Mvc;
using EconomyReloaded.Services.Services.Economy;
using EconomyReloaded.Services.Services.User;
using EconomyReloaded.ViewModels;

namespace EconomyReloaded.Controllers
{
  public class HomeController : Controller
  {
    private readonly IUserService _userService;
    private readonly IReceiptService _receiptService;

    public HomeController(IUserService userService, IReceiptService receiptService)
    {
      _userService = userService;
      _receiptService = receiptService;
    }

    // GET: Home
    public ActionResult Index()
    {
      var users = _userService.GetAllUsers();

      var userViewModel = users.Select(user => new UserSimpleViewModel { Email = user.Email, UserId = user.UserId }).ToList();

      return View("Index", userViewModel);
    }

    // GET: Home/Economy?userId=#
    public ActionResult Economy(string userId)
    {
      int uId;
      if (int.TryParse(userId, out uId))
      {
        var receipts = _receiptService.GetReceiptsOnUserId(uId);
        var user = _userService.GetById(uId);

        if (receipts != null && user != null)
        {
          var receiptViewModel = receipts.Select(r => new ReceiptViewModel { ReceiptId = r.ReceiptId, ReceiptName = r.ReceiptName, ReceiptTotal = r.TotalPrice, ReceiptDate = r.ReceiptDate });

          ViewBag.UserName = user.FirstName + " " + user.LastName;
          UserIdSessionService.SaveUserIdInSession(user.UserId);
          return View("Economy", receiptViewModel.OrderBy(r => r.ReceiptDate));
        }
      }
      return RedirectToAction("Index");
    }
  }
}