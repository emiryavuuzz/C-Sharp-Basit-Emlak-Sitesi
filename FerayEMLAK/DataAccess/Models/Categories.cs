using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Categories
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        
        public IList<Product> Product { get; set; }
     
     
    }
}
