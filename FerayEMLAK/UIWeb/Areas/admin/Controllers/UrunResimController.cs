using Bussines.Abstract;
using DataAccess.Concrete;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace UIWeb.Areas.admin.Controllers
{

    [Area("admin"), Authorize]
    public class UrunResimController : Controller
    {
        private readonly IProductImagesService ImagesService;
        private readonly IProductService productService;
        public UrunResimController(IProductImagesService ImagesService, IProductService productService)
        {
            this.ImagesService = ImagesService;
            this.productService = productService;
        }
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        [Route("/admin/UrunResim/Index")]
        public IActionResult Index(List<IFormFile> files, ProductImages productImages, Product product)
        {

            
            try
            {
                int UrunId = productService.GetAll().OrderByDescending(x => x.Id).FirstOrDefault().Id;



                productImages.ProductId = UrunId;
                productImages.Vitrin = true;
              

                if (files.Count > 0)
                {
                   
                    // İlk Eklenen Resim vitrin Olacak
                    foreach (var formFile in files)
                    {
                        
                        string DosyaUzanti = Path.GetExtension(formFile.FileName);//acb.jpg
                        string[] IzinverilenUzantilar = { ".jpg", ".jpeg", ".png" };
                        if (IzinverilenUzantilar.Contains(DosyaUzanti))
                        {
                            string filename = formFile.FileName;
                            filename = Path.GetFileName(filename);
                            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", filename);



                            var stream = new FileStream(uploadPath, FileMode.Create);
                            formFile.CopyToAsync(stream);
                            productImages.ProductId = UrunId;
                            productImages.ImagesName = filename;
                            productImages.Id = 0;
                            ImagesService.Insert(productImages);
                            productImages.Vitrin = false;
                        }
                        else
                        {
                            ViewBag.Error = "Lütfen .jpg , .jpeg , veya .png uzantılı dosya seçiniz";
                        }
                    }
                   

                    ViewBag.Message = "Resimler Yüklendi";


                }
            }
            catch (Exception)
            {

                ViewBag.Error = "Resimler Yüklenemedi";
            }

             View();
            return Redirect("/admin/Urunler/IlanYuklendi");
        }
        [HttpGet]
        [Route("/admin/UrunResim/Update/{Id}")]
        public IActionResult Update(int Id)
        {
            View(ImagesService.GetAll());
            return View(productService.GetById(x=>x.Id==Id));

        }
        [HttpPost]
        [Route("/admin/UrunResim/Update/{Id}")]
        public IActionResult Update(int Id, List<IFormFile> files, ProductImages productImages, Product product, int UrunId )
        {

            try
            {
                


                if (files.Count > 0)
                {
                    for (int i = 0; i < 40; i++)
                    {
                        ImagesService.Delete(x => x.ProductId == Id);
                    }
                    UrunId = Id;
                    productImages.Vitrin = true;
                    // İlk Eklenen Resim vitrin Olacak
                    foreach (var formFile in files)
                    {
                       
                            
                        
                        string DosyaUzanti = Path.GetExtension(formFile.FileName);//acb.jpg
                        string[] IzinverilenUzantilar = { ".jpg", ".jpeg", ".png" };
                        if (IzinverilenUzantilar.Contains(DosyaUzanti))
                        {
                            string filename = formFile.FileName;
                            filename = Path.GetFileName(filename);
                            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", filename);



                            var stream = new FileStream(uploadPath, FileMode.Create);
                            formFile.CopyToAsync(stream);
                            productImages.ProductId = UrunId;
                            productImages.ImagesName = filename;
                            productImages.Id = 0;
                            ImagesService.Insert(productImages);
                            productImages.Vitrin = false;
                        }
                        else
                        {
                            ViewBag.Error = "Lütfen .jpg , .jpeg , veya .png uzantılı dosya seçiniz";
                        }
                    }


                    ViewBag.Message = "Resimler Yüklendi";

                    }
                
            }
            catch (Exception)
            {

                ViewBag.Error = "Resimler Yüklenemedi";
            }

            View();
            return Redirect("/admin/Urunler/IlanYuklendi");
        }
    }
}
