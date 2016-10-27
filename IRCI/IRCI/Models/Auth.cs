using System;
using System.Collections.Generic;
using Npgsql;

namespace IRCI.Models
{
    public class Auth
    {
        private Connection dbConnect = new Connection();
        private NpgsqlConnection db;
        private NpgsqlCommand cmd = new NpgsqlCommand();
        private List<AuthModel> model = new List<AuthModel>();
        public Auth()
        {
            db = dbConnect.getConnection();
            db.Open();

        }
        ~Auth()
        {
            db.Close();
        }

        public List<AuthModel> login(string username, string password) {

            cmd.Connection = db;
            cmd.CommandText = "SELECT * FROM irci.auth WHERE username ='"+username +"' and password = '"+password+"'";
            try
            {
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    model.Add(new AuthModel()
                    {
                        id = reader["id"].ToString(),
                        username = reader["username"].ToString(),
                        password = reader["password"].ToString()
                    });

                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex);
            }
            return model;
        }

    }
    public class AuthModel
    {
        public string id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}