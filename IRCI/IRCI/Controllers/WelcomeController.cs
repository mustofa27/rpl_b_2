using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IRCI.Controllers
{
    public class WelcomeController : Controller
    {
        //
        // GET: /Welcome/

        public ActionResult Index()
        {
            return View();
        }

        public string hello(string name)
        {
            return HttpUtility.HtmlDecode("hello "+name);
        }

        public ActionResult hai() //tanpa paremeter --> langsung mencari di view dengan method hai
        {
            return View();
        }

        public ActionResult halo()
        {
            return View("~/Views/Home/About.cshtml");  // ~ untuk mencari pada spesifik rute
        }


    }
}
