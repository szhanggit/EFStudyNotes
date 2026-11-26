using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Standard2
{
    public class Student_Class
    {
        public int Student_ClassID { set; get; }
        public int StudentID { set; get; }
        public int ClassID { set; get; }

        public Student_Class() { }

        public static DataTable getStudent_ClassDataSet()
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(Config.getDBConnection()))
            {
                SqlCommand com = new SqlCommand(Config.getAppSettings("StudentClassInfo"), con);
                com.CommandType = CommandType.Text;

                con.Open();
                SqlDataAdapter DataAdapter = new SqlDataAdapter(com);
                DataAdapter.Fill(ds, "StudentClass");
                con.Close();
            }
            return ds.Tables[0];
        }

        public static int register(int studentid, int classid)
        {
            int studentclassid = 0;

            using(SqlConnection con = new SqlConnection(Config.getDBConnection()))
            {
                SqlCommand com = new SqlCommand("createsc", con);
                com.CommandType = CommandType.StoredProcedure;

                SqlParameter StudentParameter = com.Parameters.Add("@studentid", SqlDbType.Int);
                StudentParameter.Direction = ParameterDirection.Input;
                StudentParameter.Value = studentid;

                SqlParameter ClassParameter = com.Parameters.Add("@classid", SqlDbType.Int);
                ClassParameter.Direction = ParameterDirection.Input;
                ClassParameter.Value = classid;

                SqlParameter StudentClassID = com.Parameters.Add("@student_classid", SqlDbType.Int);
                StudentClassID.Direction = ParameterDirection.Output;

                con.Open();
                com.ExecuteNonQuery();

                try { studentclassid = Config.ConvertToInt(com.Parameters["@student_classid"].Value.ToString()); }catch(Exception){}
                con.Close();
            }

            return studentclassid;
        }

        public static List<Student_Class> getRegistrationInfo()
        {
            List<Student_Class> sccollection = new List<Student_Class>();
            Student_Class sc;

            using (SqlConnection con = new SqlConnection(Config.getDBConnection()))
            {
                SqlCommand com = new SqlCommand(Config.getAppSettings("StudentClassInfo"), con);
                com.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader datReader = com.ExecuteReader(CommandBehavior.CloseConnection);
                if (datReader.HasRows)
                { 
                    while(datReader.Read())
                    {
                        sc = new Student_Class();
                        try { sc.Student_ClassID = Config.ConvertToInt(datReader["student_classid"].ToString()); }
                        catch (Exception) { }
                        try { sc.StudentID = Config.ConvertToInt(datReader["studentid"].ToString());}
                        catch (Exception) { }
                        try { sc.ClassID = Config.ConvertToInt(datReader["classid"].ToString()); }
                        catch (Exception) { }
                        
                        sccollection.Add(sc);
                    }
                }

                con.Close();
            }

            return sccollection;
        }
    }
}