using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IRCI.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profil
        public ActionResult Index(int id = 0)
        {
            //int profilId = id; //the id in the URL
            //string data = RouteData.Values["id"] + Request.Url.Query;
            //string data = RouteData.Values["id"].ToString(); ;
            //ViewData["data"] = data;
            ViewData["id"] = id;
            return View();
        }
    }
}