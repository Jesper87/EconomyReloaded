using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EconomyReloaded.Core.Repositories;
using EconomyReloaded.Core.Repositories.User;
using EconomyReloaded.Services.Services.User;
using EconomyReloaded.ViewModels;

namespace EconomyReloaded.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Home
        public ActionResult Index()
        {
            var users = _userService.GetAllUsers();

            var userViewModel = users.Select(user => new UserSimpleViewModel { Email = user.Email, UserId = user.UserId }).ToList();

            return View("Index", userViewModel);
        }

        public ActionResult Economy(string userId)
        {
            return View("Economy");
        }
    }
}