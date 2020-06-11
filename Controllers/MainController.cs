using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FansOfAsparagus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FansOfAsparagus.Controllers
{
    public class MainController : Controller
    {
        private readonly UserContext _context;
        public static List<User> users = new List<User>();

        public MainController(UserContext context)
        {
            _context = context;
        }

        public IActionResult Index(string user)
        {
            ViewData["Head"] = user;
            users = _context.Users.ToList();
            return View(users);
        }      
    }
}
