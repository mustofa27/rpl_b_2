using System;
using System.Collections.Generic;
using Npgsql;
using Newtonsoft.Json;
using IRCI.Entity;

namespace IRCI.Models
{
    public class M_Profile
    {
        private Connection dbConnect = new Connection();
        private NpgsqlConnection db;
        private NpgsqlCommand cmd = new NpgsqlCommand();
        public M_Profile()
        {
            db = dbConnect.getConnection();
            db.Open();

        }
        ~M_Profile()
        {
            db.Close();
        }

        public string claimProfile(string id_authors = "",string auth_id ="") {
            cmd.Connection = db;
            cmd.CommandText = "UPDATE IRCI.authors SET auth_id='"+auth_id+"' WHERE id_authors='"+id_authors+"'";
            try
            {
                cmd.ExecuteNonQuery();
                return "success";
               

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex);
                return ex.ToString();
            }
            
        }
        public string unClaimProfile(string id_authors = "", string auth_id = "")
        {
            cmd.Connection = db;
            cmd.CommandText = "UPDATE IRCI.authors SET auth_id=NULL WHERE id_authors='" + id_authors + "' and auth_id='"+auth_id+"'";

            try
            {
                cmd.ExecuteNonQuery();
                return "success";


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex);
                return ex.ToString();
            }

        }
        public E_Profile detailAuthor(String id)
        {
            E_Profile profile = new E_Profile();
            cmd.Connection = db;
            cmd.CommandText = "SELECT *, UNNEST(affiliation) affiliations FROM irci.authors WHERE id_authors='" + id + "'";

            try
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    profile.author_name = reader["author_name"].ToString();
                    profile.affiliation = reader["affiliations"].ToString();
                    profile.error = "";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex);
                profile.error = ex.ToString();
            }
            return profile;
        }

    }
}