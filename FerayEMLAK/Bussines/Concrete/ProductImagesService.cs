using Core.Results;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Abstract
{
    public class ProductImagesService :Repository<ProductImages> , IProductImagesService
    {
        public ProductImagesService(FerayContext context) : base(context)
        {

        }
    }
}
