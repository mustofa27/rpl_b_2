using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRCI.Entity
{
    public class E_Authors
    {
        public string author { get; set; }
        public string department { get; set; }
        public string id_authors { get; set; }
        public string auth_id { get; set; }
        public string author_name { get; set; }
        public string affiliation { get; set; }
        public bool is_error { get; set; }
    }
}