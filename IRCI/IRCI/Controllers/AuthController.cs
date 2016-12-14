using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IRCI.Models;
using IRCI.Entity;

namespace IRCI.Controllers
{
    public class AuthController : Controller
    {
        private List<E_Auth> auth;
        private M_Auth AuthModel = new M_Auth();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public void Login(string username, string password)
        {
            auth = AuthModel.login(username, password);
            if (auth.Count == 0)
            {
                Response.Redirect("/auth");
            }
            else
            {
                Session["id"] = auth[0].id;
                Session["username"] = auth[0].username;
                Response.Redirect("/c_search/search");
            }
            
        }
        public void Logout()
        {
           
                Session.Clear();
                Response.Redirect("/c_search/search");
        }
    }
}