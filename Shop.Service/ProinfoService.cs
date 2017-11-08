using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Model;
using Shop.IService;
using Shop.IRepository;

namespace Shop.Service
{
    public class ProinfoService : BaseService<ProductInfo>, IProinfoService
    {
        public ProinfoService(IBaseRepository<ProductInfo> baseRepositroy) : base(baseRepositroy)
        {
        }
    }
}
