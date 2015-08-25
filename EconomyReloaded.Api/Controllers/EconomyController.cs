using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using EconomyReloaded.Core.Models.User;
using EconomyReloaded.Services.Services.User;

namespace EconomyReloaded.Api.Controllers
{
    public class EconomyController : ApiController
    {
        private readonly IUserService _userService;

        public EconomyController(IUserService userService)
        {
            _userService = userService;
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/Economy/GetUserDetails/{userId}")]
        public JsonResult<UserDetails> GetUserDetails(string userId)
        {
            var selectedUser = _userService.GetById(Convert.ToInt32(userId));
            var userViewModel = new UserDetails { UserId = selectedUser.UserId, FirstName = selectedUser.FirstName, LastName = selectedUser.LastName, Email = selectedUser.Email };

            return Json(userViewModel);
        }
    }
}
