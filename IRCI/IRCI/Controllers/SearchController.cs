using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IRCI.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Mencari/

        public ActionResult Index()
        {
            string keyword = Request.Form["keyword"];
            ViewBag.keyword = keyword;

            List<string> result = new List<string>();
            using (var conn = new NpgsqlConnection("Host=127.0.0.1;Username=postgres;Password=root;Database=rpl"))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    // Insert some data
                    //cmd.CommandText = "INSERT INTO data (some_field) VALUES ('Hello world')";
                    //cmd.ExecuteNonQuery();

                    // Retrieve all rows
                    cmd.CommandText = "SELECT * FROM (SELECT UNNEST(author_creator) author_creator, LOWER(UNNEST(author_creator)) author_tag FROM irci.records) t1 WHERE author_tag LIKE '%"+ keyword + "%' LIMIT 10";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Console.WriteLine(reader.GetString(0));
                            result.Add(reader.GetString(0));
                        }
                    }
                }
            }
            return View(result);
        }

        public ActionResult adminlte()
        {
            return View();
        }

    }
}
