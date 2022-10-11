using Bussines.Abstract;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;

namespace UIWeb.Controllers
{
  
    public class HomeController : Controller
    {
       
        private readonly IProductService productService;
        private readonly IProductImagesService ImagesService;
       
        private readonly IPropertiesService propertiesService;
        private readonly IAimService aimService;
        private readonly ICategoriesService categoriesService;


        public HomeController(IProductService productService, IPropertiesService propertiesService, IAimService aimService,ICategoriesService categoriesService,IProductImagesService ImagesService)
        {
            this.productService = productService;
            
            this.propertiesService = propertiesService;
            this.aimService = aimService;
           this.categoriesService = categoriesService;
            this.ImagesService = ImagesService;
        }

        public IActionResult Index()
        {
            
            View(aimService.GetAll());
            return View(productService.GetAll());
        }
        [HttpGet]
        [Route("/Home/Details/{Id}")]
        public IActionResult Details(int Id, Product product, ProductImages productImages)
        {
            View(aimService.GetAll());
            View(categoriesService.GetAll());
            View(ImagesService.GetAll());
            return View(productService.GetById(x => x.Id == Id));
        }
        public IActionResult Ilanlar(int Id ,Product product)
        {
            View(aimService.GetAll());
            View(categoriesService.GetAll());
            return View(productService.GetAll());
        }
    }
}
