using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EconomyReloaded.Data;
using EconomyReloaded.Models;
using EconomyReloaded.Repository;

namespace EconomyReloaded.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var userRepository = new UserRepository();
            var users = userRepository.GetAllUsers();

            return View(users);
        }
    }
}