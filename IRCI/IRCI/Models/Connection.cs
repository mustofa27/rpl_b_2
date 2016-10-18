using Npgsql;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRCI.Models
{
    public class Connection
    {
        private NpgsqlConnection conn;
        public Connection()
        {
           this.conn = new NpgsqlConnection("Host=localhost;Username=postgres;Password=kucinglucu;Database=irci");
        }
        public NpgsqlConnection getConnection()
        {
            return this.conn;
        }
    }
}