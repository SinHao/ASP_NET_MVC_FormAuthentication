using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_MVC_FormAuthentication.Controllers
{
    public class TestController : Controller
    {
        [Filters.CheckTestFilter]
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult UserIdentity()
        {
            bool isPass = false;
            if (this.User.Identity.IsAuthenticated)
            {
                isPass = true;
            }

            return View(isPass);
        }
    }
}