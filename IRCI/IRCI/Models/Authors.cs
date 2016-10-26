﻿using System;
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
            cmd.CommandText = "SELECT id_authors, author_name author, array_to_string(affiliation,'; ') department FROM irci.authors  WHERE LOWER(author_name)LIKE lower('%" + keyword + "%') GROUP BY author_name, affiliation, id_authors LIMIT " + limit + " OFFSET " + offset;
            try
            {
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    model.Add(new AuthorsModel()
                    {
                        author = reader["author"].ToString(),
                        department = reader["department"].ToString(),
                        id_authors = reader["id_authors"].ToString()
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
    }
}