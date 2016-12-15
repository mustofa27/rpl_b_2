using System;
using System.Collections.Generic;
using Npgsql;
using IRCI.Entity;

namespace IRCI.Models
{
    public class M_Authors
    {
        private Connection dbConnect = new Connection();
        private NpgsqlConnection db;
        private NpgsqlCommand cmd = new NpgsqlCommand();
        private List<E_Authors> model = new List<E_Authors>();
        public M_Authors()
        {
            db = dbConnect.getConnection();
            db.Open();

        }
        ~M_Authors()
        {
            db.Close();
        }
        public List<E_Authors> getAuthors(int offset = 0, int limit = 10, string keyword = "")
        {
            cmd.Connection = db;
            cmd.CommandText = "SELECT id_authors,auth_id, author_name author, array_to_string(affiliation,'; ') department FROM irci.authors  WHERE LOWER(author_name)LIKE lower('%" + keyword + "%') ORDER BY auth_id";
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
					model.Add(new E_Authors()                    {
                        //author = reader["author"].ToString(),
                        author = newauthor,
                        department = reader["department"].ToString(),
                        id_authors = reader["id_authors"].ToString(),
                        auth_id = reader["auth_id"].ToString()
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
}