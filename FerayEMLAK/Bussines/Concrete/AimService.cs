using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Abstract
{
    public class AimService : Repository<Aim>, IAimService
    {
        public AimService(FerayContext context) : base(context)
        {

        }
    }
}
