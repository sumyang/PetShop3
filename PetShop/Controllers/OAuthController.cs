using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP;//引用命名空间

using System.Configuration;//从配置文件中获取内容
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using Senparc.Weixin.MP.Helpers;
namespace PetShop.Controllers
{
    public class OAuthController : Controller
    {
        /// <summary>
        /// 授权验证的方法，在该方法中可以跳转到授权页面（url，需要自己传参数）
        /// </summary>
        /// <returns></returns>
        /// 
        //定义需要使用到的数据
        public static readonly string appID = ConfigurationManager.AppSettings["appID"];
        public static readonly string appsecret = ConfigurationManager.AppSettings["appsecret"];
        public static readonly string Domin = "http://wx.yangbin.shop";//定义好域名
        // GET: OAuth
        public ActionResult Index(string returnUrl)
        {
            //注意：回调的地址，不能简单就是一个字符串，而应该是域名下面的一个页面，必须是一个完整的链接地址
            string callBackUrl = $"{Domin}{Url.Action("CallBack", new { returnUrl })}";
            //用户自定义要给的state值，这个值就相当于验证码 用于比较只能使用一次，使用后立即清除
            string state = "wx" + DateTime.Now.Millisecond;
            //保存状态参数
            Session["state"] = state;
            //调用授权地址
            string oauthorurl = OAuthApi.GetAuthorizeUrl(appID, callBackUrl, state, OAuthScope.snsapi_userinfo);
            //跳转到授权页面
            return Redirect(oauthorurl);
        }
        ///回调函数
        ///
        public ActionResult CallBack(string code, string state, string returnUrl)
        {
            //注意:前提是先要判断用户输入进来的数据state是否满足
            if (Session["state"]?.ToString() != state)
            {
                Session["state"] = null;
                return Content("非安全方式登陆，登陆失败，请重新进入");

            }
            //把session中的数据清理
            Session["state"] = null;

            //判断用户返回的code
            if (string.IsNullOrEmpty(code))
            {
                return Content("您拒绝授权验证");
            }
            //以token换取accesstoken
            var accessToken = OAuthApi.GetAccessToken(appID, appsecret, code);//反悔的是一个token的对象
                                                                              //3.1判断是否请求成功
            if (accessToken.errcode != Senparc.Weixin.ReturnCode.请求成功)
            {
                //需要重新定位到授权页面
                return Content($"错误消息:{accessToken.errmsg}");
            }
            Session["accessToken"] = accessToken;//保存下来供过滤器验证
            //以token 和oppenid来换取用户消息
            try
            {
                OAuthUserInfo usrinfo = OAuthApi.GetUserInfo(accessToken.access_token, accessToken.openid);
                Session["userInfo"] = usrinfo;
                return Redirect(returnUrl);
            }
            catch (Exception)
            {
                //如果是没有获取到用户的信息,则需要进入到授权页面
                //var callBackUrl = $"http://wx.yangbin.shop{Url.Action("Callback", new { returnUrl })}";
                var callBackUrl = $"{Domin}{Url.Action("CallBack", new { returnUrl })}";
                // 随机数，用于加强回调请求的安全，避免被恶意请求，类似验证码
                state = "wx" + DateTime.Now.Millisecond;
                Session["state"] = state;

                //调用授权地址
                var url = OAuthApi.GetAuthorizeUrl(appID, callBackUrl, state, OAuthScope.snsapi_userinfo);
                return Redirect(url);
            }

        }
        //调用接口的配置文件
        public ActionResult jsSdkConfig()
        {

            string url = $"{Domin}{Request.RawUrl}";//构造当前请求的外网地址
            JsSdkUiPackage jssdkpackage = JSSDKHelper.GetJsSdkUiPackage(appID, appsecret, url);
            return PartialView(jssdkpackage);

        }
    }
}