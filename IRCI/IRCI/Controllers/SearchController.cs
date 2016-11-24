using System.Web.Mvc;
using System.Collections.Generic;
using IRCI.Models;

namespace IRCI.Controllers
{
    public class SearchController : Controller
    {
        private List<AuthorsModel> records;
        private Authors AuthorsModel = new Authors();
        //
        // GET: /Mencari/

        public ActionResult Index(int page = 1, string keyword = "")
        {
            page -= 1;
            //string keyword = Request.Form["keyword"];
            ViewBag.keyword = keyword;
            records = AuthorsModel.getRecords(page * 10, 10, keyword);
            return View(records);
        }

        public ActionResult adminlte()
        {
            return View();
        }

    }
}
