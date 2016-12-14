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
        private List<E_Profile> model = new List<E_Profile>();
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
        public E_Profile getProfile(String id_profile)
        {
            E_Profile profile = new E_Profile();
            cmd.Connection = db;
            cmd.CommandText = "SELECT id_authors,auth_id, author_name author, array_to_string(affiliation,'; ') department FROM irci.authors WHERE id_authors ='" + id_profile + "'";
            try
            {
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string newauthor = reader["author"].ToString();
                    if (reader["author"].ToString().Contains(","))
                    {
                        string[] authorsplit = reader["author"].ToString().Split(',');
                        newauthor = authorsplit[1] + ' ' + authorsplit[0];
                    }
                    newauthor.Replace("*", "");
                    profile=new E_Profile()
                    {
                        author_name = newauthor,
                        affiliation = reader["department"].ToString(),
                        //id_authors = reader["id_authors"].ToString(),
                        error = ""
                    };

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