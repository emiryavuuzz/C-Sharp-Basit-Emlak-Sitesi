using Bussines.Abstract;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


using System.Security.Cryptography;

namespace UIWeb.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUsersService userService;
        private readonly IProductService productService;
        private readonly IProductImagesService imagesService;
       

        public HomeController(IHttpContextAccessor contextAccessor, IUsersService userService, IProductService productService, IProductImagesService imagesService, IUsersService usersService)
        {
            _contextAccessor = contextAccessor;
            this.userService = userService;
            this.productService = productService;
           
            this.imagesService = imagesService;
            this.userService=userService;
        }
        
        public IActionResult Index(int Id, ProductImages productImages)
        {
        
            ViewBag.Resim = imagesService.GetById(x => x.ProductId == Id && x.Vitrin == true);
            return View(productService.GetAll());
        }
        public IActionResult User(int Id)
        {
            return View(userService.GetAll());
        }
        public IActionResult UserYukle()
        {
            return View();
        }
        [HttpPost]
        [Route("/admin/Home/UserYukle")]
        public IActionResult UserYukle(Users users, string sifre)
        {
            sifre = users.Password;
            SHA256Managed sha256 = new SHA256Managed();
            byte[] bitDizisi = System.Text.Encoding.UTF8.GetBytes(sifre);
            string sifreliVeri = Convert.ToBase64String(sha256.ComputeHash(bitDizisi));

            users.Password = sifreliVeri;
            
            View(userService.Insert(users));
            return Redirect("/admin/Home/User");
        }
        [Route("/admin/Home/UserDelete/{Id}")]
        public IActionResult UserDelete(int Id)
        {
                View(userService.Delete(x => x.Id == Id));
            return Redirect("/admin/Home/User");
        }
    }
}