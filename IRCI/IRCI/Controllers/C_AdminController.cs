using IRCI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IRCI.Controllers
{
    public class C_AdminController : Controller
    {
        //
        // GET: /C_Admin/
        private M_Admin AdminModel = new M_Admin();
        public ActionResult Metadata()
        {
            return View();
        }
        public ActionResult processMetadata()
        {
            AdminModel.processMetadata();
            return View();
        }
    }
}
