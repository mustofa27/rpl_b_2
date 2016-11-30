using System;
using System.Collections.Generic;
using Npgsql;

namespace IRCI.Models
{
    public class Authors
    {
        private Connection dbConnect = new Connection();
        private NpgsqlConnection db;
        private NpgsqlCommand cmd = new NpgsqlCommand();
        private List<AuthorsModel> model = new List<AuthorsModel>();
        public Authors()
        {
            db = dbConnect.getConnection();
            db.Open();

        }
        ~Authors()
        {
            db.Close();
        }
        public List<AuthorsModel> getRecords(int offset = 0, int limit = 10, string keyword = "")
        {
            cmd.Connection = db;
            cmd.CommandText = "SELECT id_authors,auth_id, author_name author, array_to_string(affiliation,'; ') department FROM irci.authors  WHERE LOWER(author_name)LIKE lower('%" + keyword + "%') LIMIT " + limit + " OFFSET " + offset;
            try
            {
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string[] authorsplit = reader["author"].ToString().Split(',');
                    string newauthor = authorsplit[1] + ' ' + authorsplit[0];
                    model.Add(new AuthorsModel()
                    {
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
    public class AuthorsModel
    {
        public string author { get; set; }
        public string department { get; set; }
        public string id_authors { get; set; }
        public string auth_id { get; set; }
    }
}