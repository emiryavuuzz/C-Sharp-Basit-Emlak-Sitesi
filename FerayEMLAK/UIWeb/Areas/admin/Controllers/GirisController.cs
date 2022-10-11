using Bussines.Abstract;
using DataAccess.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography;

namespace UIWeb.Areas.admin.Controllers
{
    [Area("admin")]
    public class GirisController : Controller
    {
        private readonly IUsersService UserService;
        public GirisController(IUsersService userService)
        {
            UserService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string Email, string Sifre, Users users)
        {

            SHA256Managed sha256 = new SHA256Managed();
            byte[] bitDizisi = System.Text.Encoding.UTF8.GetBytes(Sifre);
            string sifreliVeri = Convert.ToBase64String(sha256.ComputeHash(bitDizisi));

            
            var BulunanUser = UserService.GetById(x=>x.Email==Email && x.Password== sifreliVeri);

            if (BulunanUser != null)
            {
                if (BulunanUser.Email == Email && BulunanUser.Password == sifreliVeri)
                {

                    var Claims = new List<Claim>
                        {
                        new Claim(ClaimTypes.Name, BulunanUser.Name),
                        new Claim(ClaimTypes.Role, BulunanUser.Roles),
                        new Claim(ClaimTypes.Email, BulunanUser.Email),
                        new Claim("Id", BulunanUser.Id.ToString())
                        };
                    var UserIdentity = new ClaimsIdentity(Claims, "YöneticiClaims");
                    ClaimsPrincipal principal = new ClaimsPrincipal(UserIdentity);

                    HttpContext.SignInAsync(principal);

                    return Redirect("/admin/Home");
                }


            }
            else
            {

                ViewBag.Error = "Email ve Şifreniz Uyuşmuyor, Veya Hatalı";
                return View();
            }
            return View();

        }

        [HttpGet]
        public IActionResult UyeOl()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UyeOl(Users users)
        {
         
            return View(UserService.Insert(users));
        }
        

    }
}
