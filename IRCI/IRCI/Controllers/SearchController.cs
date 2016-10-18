using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IRCI.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Mencari/

        public ActionResult Index()
        {
            string keyword = Request.Form["keyword"];
            ViewBag.keyword = keyword;
            return View();
        }

        public ActionResult adminlte()
        {
            return View();
        }

    }
}
