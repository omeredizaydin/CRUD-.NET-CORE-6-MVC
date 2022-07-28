using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ProjectCore.Models;
using Microsoft.AspNetCore.Authentication;

namespace ProjectCore.Controllers
{
    public class LoginController : Controller
    {

        Context c = new Context();

        [HttpGet]
        public IActionResult GirisYap()
        {
            //return View("~/Views/Default/BirimGetir");
            return View();
        }

        public async Task<IActionResult> GirisYap(Admin p)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.Kullanici == p.Kullanici && x.Sifre == p.Sifre);
            if (bilgiler != null)
            {
                //TODO
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.Kullanici)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index","Personel");
            }

            return View();
            
        }
    }
}
