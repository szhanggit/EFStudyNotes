using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Standard2
{
    public class ComputerClass
    {
        public int ClassID { get; set; }
        public String ClassName { get; set; }
        public int Credit { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int teacherid { get; set; }

        public ComputerClass() { }

        public static DataTable getComputerClassDataSet()
        {
            DataSet ds = new DataSet();
            using(SqlConnection con = new SqlConnection(Config.getDBConnection()))
            {
                SqlCommand com = new SqlCommand(Config.getAppSettings("ClassInfo"), con);
                com.CommandType = CommandType.Text;
                con.Open();
                SqlDataAdapter DataAdapter = new SqlDataAdapter(com);
                DataAdapter.Fill(ds, "Class");
                con.Close();
            }

            return ds.Tables[0];
        }
    }
}