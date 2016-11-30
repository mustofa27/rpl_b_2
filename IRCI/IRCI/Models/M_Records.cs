using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRCI.Models;
using Npgsql;
using IRCI.Entity;

namespace IRCI.Models
{
    public class M_Records
    {
        private Connection dbConnect = new Connection();
        private NpgsqlConnection db;
        private NpgsqlCommand cmd = new NpgsqlCommand();
        private List<E_Records> model = new List<E_Records>();
        public M_Records()
        {
            this.db = dbConnect.getConnection();
            this.db.Open();

        }
        ~M_Records()
        {
            this.db.Close();
        }
        public List<E_Records> getRecords(string offset = "0", string limit = "10")
        {
            this.cmd.Connection = this.db;
            this.cmd.CommandText = "SELECT * FROM IRCI.RECORDS LIMIT " + limit + " OFFSET " + offset + "ORDER BY AUTH_ID";
            try
            {
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    this.model.Add(new E_Records()
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
}