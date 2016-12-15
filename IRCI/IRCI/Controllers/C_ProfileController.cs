using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IRCI.Models;
using IRCI.Entity;

namespace IRCI.Controllers
{
    public class C_ProfileController : Controller
    {
        private E_Authors author;
        private List<E_Artikel> artikel;
        private M_Profile ProfileModel = new M_Profile();
        private M_Artikel ArtikelModel = new M_Artikel();
        private List<E_Authors> authors;
        private M_Authors AuthorsModel = new M_Authors();
        // GET: Profil
        public ActionResult Show(string id = "")
        {
            if (id == "") {
                ViewBag.info = "Id belum dimasukkan";
                return View("Error");
            }
            else
            {
                author = AuthorsModel.getAuthor(id);
                artikel = ArtikelModel.getArtikelByProfile(id);
                ViewBag.author = author;
                ViewBag.artikel = artikel;
                System.Diagnostics.Debug.Write(author);
                if (author.is_error)
                {
                    ViewBag.info = "Id yang anda masukkan tidak vaild atau sedang terjadi kesalahan pada database, silahkan refresh browser atau klik back";
                    return View("Error");
                }
                else
                {
                    return View();
                }
                
            }
           
        }
        public ActionResult claim(string id_authors = "", string auth_id = "")
        {

            M_Profile profile = new M_Profile();
            string result = profile.claimProfile(id_authors, auth_id);
            if (result == "success")
            {
                Response.Redirect("/c_profile/show");
            }
            else
            {
                Response.Redirect("/c_profile/show?error=1");
            }
            return View();
        }
        public ActionResult unClaimProfile(string id_authors = "", string auth_id = "")
        {

            M_Profile profile = new M_Profile();
            string result = profile.unClaimProfile(id_authors, auth_id);
            if (result == "success")
            {
                Response.Redirect("/show");
            }
            else
            {
                Response.Redirect("/show?error=1");
            }
            return View();
        }
        public ActionResult search(int page = 1, string keyword = "")
        {
            if (keyword != "")

            {
                page -= 1;
                //string keyword = Request.Form["keyword"];
                ViewBag.keyword = keyword;
                authors = AuthorsModel.getAuthors(page * 10, 10, keyword);
            }

            return View(authors);
        }
    }
}