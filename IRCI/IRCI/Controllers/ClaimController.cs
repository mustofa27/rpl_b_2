using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IRCI.Controllers
{
    public class ClaimController : Controller
    {
        // GET: Claim
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Claim(string id="")
        {
            return View();
        }
    }
}