using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FansOfAsparagus.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FansOfAsparagus.Controllers
{
    [Route("profile")]
    public class ProfileController : Controller
    {
        [Route("")]
        [Authorize]
        public IActionResult Index()
        {
            string email = "";
            User profileFB = null;
            if (User != null)
            {
                foreach (var claim in User.Claims)
                {
                    if (claim.Type.Contains("email"))
                    {
                        email = claim.Value;
                    }
                }
                profileFB = new User
                {
                    Name = User.Identity.Name,
                    Email = email
                };
            }            
            return RedirectToAction("Index", "Home", profileFB);
        }
    }
}
