using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EconomyReloaded.Core.Repositories;

namespace EconomyReloaded.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _userRepository;

        public HomeController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        // GET: Home
        public ActionResult Index()
        {
            var users = _userRepository.GetAllUsers();

            return View(users);
        }
    }
}