using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IRCI.Models;
using IRCI.Entity;

namespace IRCI.Controllers
{
    public class RecordsController : Controller
    {
        private List<E_Artikel> records;
        private M_Artikel RecordModel = new M_Artikel();
        // GET: Records
        public ActionResult Index(int page=0)
        {

            records = RecordModel.getRecords((page * 10).ToString(),"10");
            return View(records);
        }

    }
}