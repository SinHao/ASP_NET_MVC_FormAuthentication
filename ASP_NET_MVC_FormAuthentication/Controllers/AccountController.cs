using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_MVC_FormAuthentication.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Verify(string user, string password)
        {
            if ((user.Equals("test") & password.Equals("test")) ||
                (user.Equals("test2") & password.Equals("test")))
            {
                var now = DateTime.Now;
                var ticket = new System.Web.Security.FormsAuthenticationTicket(user, true, 30);

                var encryptedTicket = System.Web.Security.FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(System.Web.Security.FormsAuthentication.FormsCookieName, encryptedTicket);
                Response.Cookies.Add(cookie);

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Logout()
        {
            //// 使用內建SignOut方法
            System.Web.Security.FormsAuthentication.SignOut();
            return View();
        }
    }
}