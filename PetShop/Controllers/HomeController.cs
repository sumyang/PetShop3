using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Model;
using Shop.IService;

namespace PetShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        /// <summary>
        /// 首页数据查询
        /// </summary>
        /// <returns></returns>
        /// 
        public IBannerService BannerService { get; set; }
        public IBannerService NoticeService { get; set; }
        public ActionResult Index()
        {
            var BannerResult = BannerService.GetEntities(x => true);
            ViewBag.Banner = BannerResult.ToList();

            var NoticeResult = NoticeService.GetEntities(x => true);
            ViewBag.Notice = NoticeResult.ToList();

            return View();


         
        }
        public ActionResult Notice()
        {
            return View();
        }
    }
}