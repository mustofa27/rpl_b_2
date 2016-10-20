using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRCI.Models;
using Npgsql;

namespace IRCI.Models
{
    public class Records
    {
        private Connection dbConnect = new Connection();
        private NpgsqlConnection db;
        private NpgsqlCommand cmd = new NpgsqlCommand();
        private List<RecordsModel> model = new List<RecordsModel>();
        public Records()
        {
            this.db = dbConnect.getConnection();
            this.db.Open();

        }
        ~Records()
        {
            this.db.Close();
        }
        public List<RecordsModel> getRecords(string offset = "0", string limit = "10")
        {
            this.cmd.Connection = this.db;
            this.cmd.CommandText = "SELECT * FROM IRCI.RECORDS LIMIT " + limit + " OFFSET " + offset;
            try
            {
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    this.model.Add(new RecordsModel()
                    {
                        id_record = reader["id_record"].ToString()

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
    public class RecordsAuthorClass
    {
        private Connection dbConnect = new Connection();
        private NpgsqlConnection db;
        private NpgsqlCommand cmd = new NpgsqlCommand();
        private List<RecordsAuthor> model = new List<RecordsAuthor>();
        public RecordsAuthorClass()
        {
            this.db = dbConnect.getConnection();
            this.db.Open();

        }
        ~RecordsAuthorClass()
        {
            this.db.Close();
        }
        public List<RecordsAuthor> getRecords(int offset = 0, int limit = 10, string keyword = "")
        {
            this.cmd.Connection = this.db;
            this.cmd.CommandText = "SELECT REPLACE(author,' .','') author, department FROM (SELECT REPLACE(CONCAT(split_part(author,',',2), ' ', split_part(author,',',1)),'-','') author, department FROM(SELECT split_part(author_creator, ';', 1) author, split_part(author_creator, ';', 2) department FROM(SELECT DISTINCT(author_creator) author_creator FROM(SELECT REPLACE(UNNEST(author_creator), '*', '') author_creator FROM irci.records) t1) t2 ORDER BY author) t3) t4 WHERE author NOT IN('  ', ' ') AND LOWER(author)LIKE lower('%" + keyword + "%') LIMIT " + limit + " OFFSET " + offset;
            try
            {
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    this.model.Add(new RecordsAuthor()
                    {
                        author = reader["author"].ToString(),
                        department = reader["department"].ToString()
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
    public class RecordsModel
    {
        public string id_record { get; set; }

    }
    public class RecordsAuthor
    {
        public string author { get; set; }
        public string department { get; set; }

    }
}