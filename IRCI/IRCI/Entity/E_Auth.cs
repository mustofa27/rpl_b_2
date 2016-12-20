using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRCI.Entity
{
    public class E_Auth
    {
        public string id_auth { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string is_admin { get; set; }
    }
}