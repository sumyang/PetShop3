using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
namespace PetShop.Controllers
{
    public class OAthinfoController : Controller
    {
        // GET: OAthinfo
        public ActionResult Index()
        {
            var userInfo = Session["userInfo"] as OAuthUserInfo;
            return View(userInfo);
        }
    }
}