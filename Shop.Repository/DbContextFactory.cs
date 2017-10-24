using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Model;
using System.Runtime.Remoting.Messaging;
namespace Shop.Repository
{
    /// <summary>
    /// 专门实例化上下文
    /// </summary>
  public  class DbContextFactory
    {
        public static PestShow CreateDbContext()
        {
            PestShow wshop = CallContext.GetData("DbContext") as PestShow;
            if (wshop == null)
            {
                wshop = new PestShow();
                CallContext.SetData("DbContext", wshop);//如果通道中没有该参数，则向通道中添加该参数
                return wshop;
            }
            return wshop;
        }
    }
}
