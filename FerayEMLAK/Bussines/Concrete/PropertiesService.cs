using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Abstract
{
    public class PropertiesService : Repository<Properties> , IPropertiesService
    {
        public PropertiesService(FerayContext context) : base(context)
        {

        }
    }
}
