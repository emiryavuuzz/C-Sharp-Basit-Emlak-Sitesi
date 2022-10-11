using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataAccess.Models
{
    public class Product 
    {
      

        public int Id { get; set; }
        public string Name { get; set; }
        public string Explanation { get; set; }
        public DateTime Date { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string FullAdress { get; set; }
        public string ImarDurumu { get; set; }
        public int CategoriesId { get; set; } 
        public int AimId { get; set; }
        public Decimal Price { get; set; }
        public int Age { get; set; }
        public string Room { get; set; }
        public string Floor { get; set; }
        public string UsingStatus { get; set; }
        public string DeedStatus { get; set; }
        public string Olcu { get; set; }
        public bool Status { get; set; }  // true: aktif false: yayın dışı
        public string Images { get; set; } = "defaultimg.jpg";
        public bool Vitrin { get; set; } // true ise ana ekran slider da dönebilecek
     

        public  Aim Aim { get; set; }
        public  Categories Categories { get; set; }
     
       

        public IList<Properties> Properties { get; set; }
      
        public  IList<ProductImages> ProductImages { get; set; }
    }
}
