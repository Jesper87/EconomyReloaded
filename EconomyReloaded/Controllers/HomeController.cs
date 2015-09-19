﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EconomyReloaded.Core.Models.Economy;
using EconomyReloaded.Services.Services.Economy;
using EconomyReloaded.Services.Services.User;
using EconomyReloaded.ViewModels;
using EconomyReloaded.ViewModelServices;

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
      if (!int.TryParse(userId, out uId))
        return RedirectToAction("Index");

      var receipts = _receiptService.GetReceiptsOnUserId(uId);
      var user = _userService.GetById(uId);

      if (receipts == null || user == null)
        return RedirectToAction("Index");

      var sortedModel = BuildViewModel(receipts);

      ViewBag.UserName = user.FirstName + " " + user.LastName;
      UserIdSessionService.SaveUserIdInSession(user.UserId);
      return View("Economy", sortedModel);
    }

    private Dictionary<string, List<ReceiptViewModel>> BuildViewModel(IEnumerable<Receipt> receipts)
    {
      var receiptViewModel = receipts.Select(r => new ReceiptViewModel { ReceiptId = r.ReceiptId, ReceiptName = r.ReceiptName, ReceiptTotal = r.TotalPrice, ReceiptDate = r.ReceiptDate });
      var sortedModel = SortReceiptViewModelsByDate.Sort(receiptViewModel);
      return sortedModel;
    }
  }


}