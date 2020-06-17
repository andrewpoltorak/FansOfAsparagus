using Microsoft.AspNetCore.Mvc;

namespace FansOfAsparagus.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        [Route("signin")]
        public IActionResult SignIn()
        {
            return View();
        }

        [Route("signin/{provider}")]
        public IActionResult SignIn(string provider, string returnUrl = null)
        {            
            return Challenge(new Microsoft.AspNetCore.Authentication.AuthenticationProperties { RedirectUri = returnUrl ?? "/" }, provider);
        }
    }
}
