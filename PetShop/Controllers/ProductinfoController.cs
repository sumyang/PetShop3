using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Model;
using Shop.IService;
namespace PetShop.Controllers
{
    public class ProductinfoController : Controller
    {
        // GET: Productinfo
        /// <summary>
        /// 商品详情页
        /// </summary>
        /// <returns></returns>
        /// 
        public IProinfoService ProinfoService { get; set; }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Proinfo(int? id)
        {
            var ProinfoResult = ProinfoService.GetEntities(x => x.id==id);
            ViewBag.Proinfox = ProinfoResult.ToList();
            return View();
        }
    }
}