using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Standard2
{
    public class Student
    {
        public int StudentID { set; get; }
        public String StudentName { set; get; }
        public int Gender { set; get; }

        public Student() { }

        public static DataTable getStudentDataSet()
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(Config.getDBConnection()))
            {
                SqlCommand com = new SqlCommand(Config.getAppSettings("StudentInfo"), con);
                com.CommandType = CommandType.Text;
                con.Open();
                SqlDataAdapter DataAdapter = new SqlDataAdapter(com);
                DataAdapter.Fill(ds, "Student");
                con.Close();
            }
            return ds.Tables[0];
        }
    }
}