using System;
using System.Collections.Generic;
using Npgsql;
using IRCI.Entity;

namespace IRCI.Models
{
    public class M_Auth
    {
        private Connection dbConnect = new Connection();
        private NpgsqlConnection db;
        private NpgsqlCommand cmd = new NpgsqlCommand();
        private List<E_Auth> model = new List<E_Auth>();
        public M_Auth()
        {
            db = dbConnect.getConnection();
            db.Open();

        }
        ~M_Auth()
        {
            db.Close();
        }

        public List<E_Auth> login(string username, string password) {

            cmd.Connection = db;
            cmd.CommandText = "SELECT * FROM irci.auth WHERE username ='"+username +"' and password = '"+password+"'";
            try
            {
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    model.Add(new E_Auth()
                    {
                        id_auth = reader["id_auth"].ToString(),
                        username = reader["username"].ToString(),
                        password = reader["password"].ToString(),
                        is_admin = reader["is_admin"].ToString()
                    });
                    

                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex);
            }
            return model;
        }
        public Boolean logout()
        {
            return true;
        }

    }
}