using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;

namespace Standard
{
    public class Config
    {
        public static String getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        }

        public static String getAppSettings(String key)
        { 
            return ConfigurationManager.AppSettings[key].ToString();
        }
    }
}


