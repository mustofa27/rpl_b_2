using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRCI.Models
{
    public class M_Admin
    {
        private Connection dbConnect = new Connection();
        private NpgsqlConnection db;
        private NpgsqlCommand cmd = new NpgsqlCommand();
        public M_Admin()
        {
            db = dbConnect.getConnection();
            db.Open();

        }
        ~M_Admin()
        {
            db.Close();
        }
        public string processMetadata()
        {
            cmd.Connection = db;
            cmd.CommandText = "SELECT processMetadata()";
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