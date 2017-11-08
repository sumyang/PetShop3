using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace PetShop.Filters
{
    public class OAuthAttribute:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //当用户进入第三方网站得时候，需要先判断用户是否已经被授权》》token
            if (filterContext.HttpContext.Session["accessToken"] == null)
            {
                //跳转：跳转到授权验证页面
                //（自己写构造的url地址（授权验证地址））还需要获取最初的请求地址
                //如何获取当前的请求地址
                string returnUrl = filterContext.HttpContext.Request.RawUrl;//这是本地地址，你希望访问的第三方
                UrlHelper url = new UrlHelper(filterContext.RequestContext);
                //因为请求不成功所以用户需要授权页面
                filterContext.Result = new RedirectResult(url.Action("Index", "OAuth", new { returnUrl }));
            }
            //base.OnAuthorization(filterContext);
        }
    }
}