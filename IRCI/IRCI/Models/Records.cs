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
        public List<RecordsModel> getRecords(string offset="0",string limit="10")
        {
            this.cmd.Connection = this.db;
            this.cmd.CommandText = "SELECT * FROM IRCI.RECORDS LIMIT "+limit+" OFFSET "+offset;
            try
            {
                var reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    this.model.Add(new RecordsModel() { 
                        id_record = reader["id_record"].ToString()

                    });

                }

            }
            catch(Exception ex)
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
}