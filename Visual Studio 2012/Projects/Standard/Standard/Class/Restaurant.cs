using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Standard
{
    public class Restaurant
    {
        public String name { get; set; }
        public String address { get; set; }
        public String phone { get; set; }
        public String webaddress { get; set; }
        public String email { get; set; }
        public List<Menu> menu { get; set; }
    }
}