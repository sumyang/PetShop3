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
    public class PSortService : BaseService<ProductSort>, IPSortService
    {
        public PSortService(IBaseRepository<ProductSort> baseRepositroy) : base(baseRepositroy)
        {
        }
    }
}
