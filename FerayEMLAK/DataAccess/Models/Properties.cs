using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Properties 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
  
        public bool Status { get; set; } = true;

        public Product Product { get; set; }
      
    }
}
