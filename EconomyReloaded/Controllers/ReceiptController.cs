using System;
using System.Web.Mvc;
using EconomyReloaded.Core.Models.Economy;
using EconomyReloaded.Services.Services.Economy;
using EconomyReloaded.Services.Services.User;
using EconomyReloaded.ViewModels;

namespace EconomyReloaded.Controllers
{
  public class ReceiptController : Controller
  {
    private readonly IReceiptService _receiptService;


    public ReceiptController(IReceiptService receiptService)
    {
      _receiptService = receiptService;
    }

    public ActionResult AddReceipt()
    {
      if (Request.IsAjaxRequest() && UserIdExists())
      {

        return PartialView("_AddReceipt", new CreateReceiptViewModel { UserId = UserIdSessionService.UserId, ReceiptDate = DateTime.Today });
      }
      return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult CreateReceipt(CreateReceiptViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return RedirectToAction("Economy", "Home", new { userId = model.UserId });
      }

      InsertReceipt(model);
      return RedirectToAction("Economy", "Home", new { userId = model.UserId });
    }

    [HttpGet]
    [ChildActionOnly]
    public ActionResult DeleteReceipe(string receiptId)
    {
      return PartialView("_DeleteReceipt", new DeleteReceiptViewModel { ReceiptId = receiptId });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteReceipt(DeleteReceiptViewModel model)
    {

      int rId;
      if (int.TryParse(model.ReceiptId, out rId) && ModelState.IsValid && UserIdExists())
      {
        _receiptService.DeleteReceipt(rId);
      }

      return RedirectToAction("Economy", "Home", new { UserIdSessionService.UserId });

    }

    public ActionResult EditReceipt()
    {
      throw new NotImplementedException();
    }

    private bool UserIdExists()
    {
      return !string.IsNullOrEmpty(UserIdSessionService.UserId);
    }

    private void InsertReceipt(CreateReceiptViewModel model)
    {
      int uId;
      decimal price;

      if (!int.TryParse(model.UserId, out uId) || !decimal.TryParse(model.ReceiptTotal, out price))
        return;

      var receipt = new Receipt
      {
        UserId = uId,
        ReceiptName = model.ReceiptName,
        TotalPrice = price,
        ReceiptDate = model.ReceiptDate
      };

      _receiptService.InsertReceipt(receipt);
    }
  }
}