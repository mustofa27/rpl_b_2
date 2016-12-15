using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRCI.Models;
using Npgsql;
using IRCI.Entity;

namespace IRCI.Models
{
    public class M_Artikel
    {
        private Connection dbConnect = new Connection();
        private NpgsqlConnection db;
        private NpgsqlCommand cmd = new NpgsqlCommand();
        private List<E_Artikel> model = new List<E_Artikel>();
        public M_Artikel()
        {
            this.db = dbConnect.getConnection();
            this.db.Open();

        }
        ~M_Artikel()
        {
            this.db.Close();
        }
        public List<E_Artikel> getArtikelByProfile(string id)
        {
            this.cmd.Connection = this.db;
            this.cmd.CommandText = "SELECT REPLACE(REPLACE(title,'â€',''),'œ','') title, theyear, SUM(cited) cited FROM (SELECT id_artikel, (SELECT title FROM irci.artikel WHERE id_artikel=aa.id_artikel LIMIT 1) title, (SELECT theyear FROM irci.artikel WHERE id_artikel=aa.id_artikel LIMIT 1) theyear, (SELECT COUNT(theyear) FROM irci.artikel_referensi WHERE id_referensi_artikel=aa.id_artikel LIMIT 1) cited FROM irci.artikel_authors aa WHERE id_authors='" + id+"' GROUP BY id_artikel) t1 GROUP BY title, theyear ORDER BY theyear DESC";
            try
            {
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    this.model.Add(new E_Artikel()
                    {
                        title = reader["title"].ToString(),
                        theyear = reader["theyear"].ToString(),
                        cited = reader["cited"].ToString()
                    });

                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex);
            }
            return this.model;

        }

    }
}