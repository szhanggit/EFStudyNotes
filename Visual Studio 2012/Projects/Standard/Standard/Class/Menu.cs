using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Standard
{
    public class Menu
    {
        public String name { set; get; }
        public Double price { set; get; }
        public String desc { set; get; }
        public int star { set; get; }
    }
}