using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using System.Web.Mvc;
using EconomyReloaded.Core.Models.User;
using EconomyReloaded.Services.Services.Economy;
using EconomyReloaded.Services.Services.User;
using Newtonsoft.Json;

namespace EconomyReloaded.Api.Controllers
{
    public class EconomyController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IReceiptService _receiptService;

        public EconomyController(IUserService userService, IReceiptService receiptService)
        {
            _userService = userService;
            _receiptService = receiptService;
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Http.Route("api/Economy/GetUserDetails/{userId}")]
        public JsonResult<UserDetails> GetUserDetails(string userId)
        {
            int uId;
            if (int.TryParse(userId, out uId))
            {
                var selectedUser = _userService.GetById(Convert.ToInt32(userId));
                if (selectedUser != null)
                    return Json(selectedUser);
            }
            return Json(new UserDetails());
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Http.Route("api/Economy/GetReceiptsForUser/{userId}")]
        public JsonResult<IEnumerable<ReceiptHalFormat>> GetReceiptsForUser(string userId)
        {
            int uId;
            if (int.TryParse(userId, out uId))
            {
                var receipts = _receiptService.GetReceiptsOnUserId(uId);
                if (receipts == null)
                    return Json(Enumerable.Empty<ReceiptHalFormat>());

                var receiptsHalFormat =
                    receipts.Select(
                        r =>
                            new ReceiptHalFormat
                            {
                                ReceiptDate = r.ReceiptDate,
                                UserId = r.UserId,
                                TotalPrice = r.TotalPrice,
                                ReceiptName = r.ReceiptName,
                                ReceiptId = r.ReceiptId
                            });
                return Json(receiptsHalFormat);
            }
            return Json(Enumerable.Empty<ReceiptHalFormat>());
        }
    }
}
