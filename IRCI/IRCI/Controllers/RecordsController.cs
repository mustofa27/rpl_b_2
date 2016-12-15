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
        public ActionResult Index(string id="")
        {
            records = RecordModel.getArtikelByProfile(id);
            return View(records);
        }

    }
}