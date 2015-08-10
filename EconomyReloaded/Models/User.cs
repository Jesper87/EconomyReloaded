using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EconomyReloaded.Models
{
    public class User
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; }
    }
}