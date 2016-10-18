using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IRCI.Models;

namespace IRCI.Controllers
{
    public class RecordsController : Controller
    {
        private List<RecordsModel> records;
        private Records RecordModel = new Records();
        // GET: Records
        public ActionResult Index(int page=0)
        {

            records = RecordModel.getRecords((page * 10).ToString(),"10");
            return View(records);
        }

    }
}