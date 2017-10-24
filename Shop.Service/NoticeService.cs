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
    public class NoticeService : BaseService<Notice>, INoticeService
    {
        public NoticeService(IBaseRepository<Notice> baseRepositroy) : base(baseRepositroy)
        {
        }
    }
}
