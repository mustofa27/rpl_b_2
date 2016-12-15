using System.Web.Mvc;
using System.Collections.Generic;
using IRCI.Models;
using IRCI.Entity;

namespace IRCI.Controllers
{
    public class C_SearchController : Controller
    {
        private List<E_Authors> records;
        private M_Authors AuthorsModel = new M_Authors();
        //
        // GET: /Mencari/

        /*public ActionResult search(int page = 1, string keyword = "")
        {
            if (keyword != "")

            {
                page -= 1;
                //string keyword = Request.Form["keyword"];
                ViewBag.keyword = keyword;
                records = AuthorsModel.getRecords(page * 10, 10, keyword);
            }

            return View(records);
        }*/

        public ActionResult adminlte()
        {
            return View();
        }

    }
}
