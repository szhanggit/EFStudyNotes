using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Standard2
{
    public class Config
    {
        public static String getDBConnection()
        {
            return ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
        }

        public static String getAppSettings(String key)
        { 
            return ConfigurationManager.AppSettings[key];
        }

        public static int ConvertToInt(String token)
        {
            int result = 0;
            try {
                int.TryParse(token, out result);
                return result;
            }
            catch (Exception) { return 0; }
        }
    }
}