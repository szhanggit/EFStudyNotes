using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Standard2
{
    public class Teacher
    {
        public int TeacherID { set; get; }
        public String TeacherName { set; get; }
        public int Gender { set; get; }

        public Teacher() { }

        public static DataTable getTeacherDataSet()
        {
            DataSet ds = new DataSet();
            using(SqlConnection con = new SqlConnection(Config.getDBConnection()))
            {
                SqlCommand com = new SqlCommand(Config.getAppSettings("TeacherInfo"), con);
                com.CommandType = CommandType.Text;
                con.Open();
                SqlDataAdapter DataAdapter = new SqlDataAdapter(com);
                DataAdapter.Fill(ds, "Teacher");
                con.Close();
            }
            return ds.Tables[0];
        }
    }
}