using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EconomyReloaded.Core.Models.Economy;
using EconomyReloaded.Services.Services.Economy;
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
            if (Request.IsAjaxRequest())
            {
                var userId = TempData["userId"] != null ? TempData["userId"].ToString() : string.Empty;
                return PartialView("_AddReceipt", new CreateReceiptViewModel { UserId = userId, ReceiptDate = DateTime.Today});
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateReceipt(CreateReceiptViewModel model)
        {
            if (!ModelState.IsValid) return null;

            InsertReceipt(model);

            return RedirectToAction("Economy", "Home", new { userId = model.UserId });
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