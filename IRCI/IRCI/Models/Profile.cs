using System;
using System.Collections.Generic;
using Npgsql;

namespace IRCI.Models
{
    public class Profile
    {
        private Connection dbConnect = new Connection();
        private NpgsqlConnection db;
        private NpgsqlCommand cmd = new NpgsqlCommand();
        private List<AuthorsModel> model = new List<AuthorsModel>();
        public Profile()
        {
            db = dbConnect.getConnection();
            db.Open();

        }
        ~Profile()
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

    }

}