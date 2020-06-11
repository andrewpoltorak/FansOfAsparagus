using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FansOfAsparagus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FansOfAsparagus.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserContext _context;
        public static List<User> users = new List<User>();

        public HomeController(UserContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CheckUserAsync(string name, string email)
        {
            User user = await _context.Users.FirstOrDefaultAsync(user => user.Email == email);
            if (user != null)
            {
                if (name == user.Name)
                {
                    user.Count++;
                    user.Date = DateTime.Now;
                    await _context.SaveChangesAsync();
                    return Main(user);
                }
                else
                {
                    ModelState.AddModelError("Name", "User with this email already exists and has another name");
                    return View("Index"); 
                }
                
            }
            else
            {
                return await CreateAsync(name, email);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(string name, string email)
        {          
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Name = name,
                    Email = email
                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return Main(user);
            }
            else
            {
                return View("Index");
            }            
        }

        public IActionResult Main(User user)
        {
            return RedirectToAction("Index", "Main", user.Name);
        }
    }
}