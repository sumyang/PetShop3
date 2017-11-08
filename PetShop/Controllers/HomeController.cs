using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Model;
using Shop.IService;

using PetShop.Filters;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;

namespace PetShop.Controllers
{
    [OAuth]
    public class HomeController : Controller
    {
        // GET: Home
        /// <summary>
        /// 首页数据查询
        /// 分类页数据
        /// </summary>
        /// <returns></returns>
        /// 
        public IBannerService BannerService { get; set; }
        public INoticeService NoticeService { get; set; }
        public IProinfoService ProinfoService { get; set; }
        public IPSortService PSortService { get; set; }
        public IOAinfoService OAinfoService { get; set; }
        public ActionResult Index()
        {
            var userInfo = Session["userInfo"] as OAuthUserInfo;

            //这里是轮播图
            var BannerResult = BannerService.GetEntities(x => true);
            ViewBag.Banner = BannerResult.ToList();


            //商品信息前三个
            var ProinfoResult = ProinfoService.GetEntities(x => true);
            ViewBag.Proinfo = ProinfoResult.Take(3).ToList();


            //向数据库中增加数据
            //OAuthInfo oa = Session["userInfo"] as OAuthInfo;
            //OAuthInfo oa = new OAuthInfo();
            //oa.openId = userInfo.openid;
            //oa.NickName = userInfo.nickname;
            //oa.Tel = userInfo.province + userInfo.city;
            //OAinfoService.Add(OAuthInfo,)



            return View(userInfo);
            //return View();



        }
        public ActionResult Notice()
        {
            var NoticeResult = NoticeService.GetEntities(x => true);
            ViewBag.Notice = NoticeResult.ToList();
            return View();
        }

        public ActionResult Sort(int? id)
        {
            var PSortResult = PSortService.GetEntities(x => x.Fid==null);
            ViewBag.PSort = PSortResult.ToList();
            if(id==null)
            {
                id = 1;
            }
            var PSortResultz = PSortService.GetEntities(x => x.Fid == id);
            ViewBag.PSortz = PSortResultz.ToList();
            return View();
        }
        public ActionResult Sortda(int? id)
        {
            var ProinfoResult = ProinfoService.GetEntities(x => x.psid==id);
            ViewBag.ProinfoSor = ProinfoResult.ToList();
            return View();
        }


    }
}