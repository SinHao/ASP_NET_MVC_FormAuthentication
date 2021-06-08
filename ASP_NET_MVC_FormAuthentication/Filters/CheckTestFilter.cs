using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_MVC_FormAuthentication.Filters
{
    public class CheckTestFilter : System.Web.Mvc.AuthorizeAttribute
    {
        /// <summary>
        /// 確認是不是 test 使用者
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!httpContext.User.Identity.IsAuthenticated)
            {
                return false;
            }

            if (!httpContext.User.Identity.Name.ToUpper().Equals("TEST"))
            {
                return false;
            }

            return base.AuthorizeCore(httpContext);
        }

        /// <summary>
        /// 如果不是授權的就送出 403
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.StatusCode = 403;
            filterContext.HttpContext.Response.StatusDescription = "Forbidden";
            filterContext.HttpContext.Response.End();
            filterContext.HttpContext.Response.Close();
        }
    }
}