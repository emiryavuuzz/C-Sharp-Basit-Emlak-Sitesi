using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Abstract
{
    public class CategoriesService : Repository<Categories> , ICategoriesService
    {
        public CategoriesService(FerayContext context) : base(context)
        {

        }
    }
}
