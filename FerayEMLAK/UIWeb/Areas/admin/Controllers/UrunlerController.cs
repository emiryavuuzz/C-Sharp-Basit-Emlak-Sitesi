using Bussines.Abstract;
using Core.Results;
using Core.Results.ComplexTypes;
using DataAccess.Concrete;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web;

namespace UIWeb.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class UrunlerController : Controller
    {
       
        private readonly IProductService productservice;
        private readonly ICategoriesService categoriesService;
        private readonly IProductImagesService ImagesService;
        private readonly IAimService aimService;
        private readonly DbContext db;

        public UrunlerController(IProductService productservice, IProductImagesService ImagesService,ICategoriesService categoriesService, IAimService aimService)
        {
            this.productservice = productservice;
            this.ImagesService = ImagesService;
            this.categoriesService = categoriesService;
            this.aimService = aimService;
        }

        public IActionResult Index()
        {
            return View(productservice.GetAll());
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Insert (Product product , IFormFile file)
        {
            product.Date = DateTime.Now;
            product.Vitrin = false;
            product.Status = true;

            try
            {
                if (file != null)
                {

                    string DosyaUzanti = Path.GetExtension(file.FileName);//acb.jpg
                    string[] IzinverilenUzantilar = { ".jpg", ".jpeg", ".png" };
                    if (IzinverilenUzantilar.Contains(DosyaUzanti))
                    {
                        string RastgeleAd = Guid.NewGuid() + DosyaUzanti;
                        string KayitYeri = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{RastgeleAd}");



                        using (var Stream = new FileStream(KayitYeri, FileMode.Create))
                        {
                            file.CopyTo(Stream);

                        }

                        product.Images = RastgeleAd;
                        ViewBag.Message = productservice.Insert(product);

                    }


                    ViewBag.Message = productservice.Insert(product);

                }
                else
                {
                    ViewBag.Error = "Resim Ekleyiniz";
                }
            }
            catch (Exception)
            {

                ViewBag.Message = "Bilgiler Kaydedilemedi";
            }
            return Redirect("/admin/UrunResim/Index");
        }
        [HttpGet]
        [Route("/admin/Urunler/Update/{Id}")]
        public IActionResult Update(int Id)
        {
            View(categoriesService.GetAll());
            View(aimService.GetAll());
            return View(productservice.GetById(x => x.Id == Id));
        }
        [HttpPost]
        [Route("/admin/Urunler/Update/{Id}")]


        public IActionResult Update(int Id, Product product, IFormFile file, ProductImages productImages)
        {

            product.Date = DateTime.Now;
            product.Status = true;
            product.Vitrin = false;
            if (file != null)
            {
                string DosyaUzanti = Path.GetExtension(file.FileName);
                string[] IzinVerilenUzantilar = { ".jpg", ".jpeg", ".png" };
                if (IzinVerilenUzantilar.Contains(DosyaUzanti))
                {
                    string RastgeleAd = Guid.NewGuid() + DosyaUzanti;
                    string KayitYeri = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{RastgeleAd}");

                    using (var Stream = new FileStream(KayitYeri, FileMode.Create))
                    {
                        file.CopyTo(Stream);
                    }
                    product.Images = RastgeleAd;
                    ViewBag.Message = productservice.Update(product);
                }
                else
                {
                    ViewBag.Error = ("Lütfen jpg , jpeg veya png uazntılı dosya seçiniz");
                }

            }
            else
            {
                ViewBag.Mesage = productservice.Update(product);
            }

            return Redirect("/admin/UrunResim/Update/"+product.Id);
        }
        [HttpGet]
        [Route("/admin/Urunler/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            productservice.Delete(x => x.Id == Id);
            return Redirect("/admin/Home/index");

        }
        [Route("/admin/Urunler/IlanYuklendi")]
        public IActionResult IlanYuklendi()
        {
            return View();
        }
        [HttpGet]
        [Route("/admin/Urunler/VitrinUpdate/{Id}")]
        public IActionResult VitrinUpdate(int Id)
        {
            View(categoriesService.GetAll());
            View(aimService.GetAll());
            return View(productservice.GetById(x => x.Id == Id));
        }

        [HttpPost]
        [Route("/admin/Urunler/VitrinUpdate/{Id}")]
        public IActionResult VirinUpdate(Product product)
        {
            product.Date = DateTime.Now;
            product.Status = true;
            product.Vitrin = true;
            productservice.Update(product);
            return Redirect("/admin/Home/Index");
        }
        [HttpGet]
        [Route("/admin/Urunler/YayindanKaldir/{Id}")]
        public IActionResult YayindanKaldir(int Id)
        {
            View(categoriesService.GetAll());
            View(aimService.GetAll());
            return View(productservice.GetById(x => x.Id == Id));
        }

        [HttpPost]
        [Route("/admin/Urunler/YayindanKaldir/{Id}")]
        public IActionResult YayindanKaldir(Product product)
        {
            product.Date = DateTime.Now;
            product.Vitrin = false;
           
            product.Status = false;
            
            productservice.Update(product);
            return Redirect("/admin/Home/Index");
        }
        [HttpGet]
        [Route("/admin/Urunler/YayinaAl/{Id}")]
        public IActionResult YayinaAl(int Id)
        {
            View(categoriesService.GetAll());
            View(aimService.GetAll());
            return View(productservice.GetById(x => x.Id == Id));
        }

        [HttpPost]
        [Route("/admin/Urunler/YayinaAl/{Id}")]
        public IActionResult YayinaAl(Product product)
        {
            product.Date = DateTime.Now;
            product.Vitrin = false;

            product.Status = true;

            productservice.Update(product);
            return Redirect("/admin/Home/Index");
        }
    }
}
