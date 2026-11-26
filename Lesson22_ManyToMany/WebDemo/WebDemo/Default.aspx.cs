using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDemo.EF;

namespace WebDemo
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EmployeeDBContext employeeDBContext = new EmployeeDBContext();

            GridView1.DataSource = (from student in employeeDBContext.MTMStudents
                                   from course in student.MTMCourses
                                   select new
                                   {
                                       StudentName = student.StudentName,
                                       CourseName = course.CourseName
                                   }).ToList();
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EmployeeDBContext employeeDBContext = new EmployeeDBContext();
            MTMCours WCFCourse = employeeDBContext.MTMCourses
                .FirstOrDefault(x => x.CourseID == 4);

            employeeDBContext.MTMStudents.FirstOrDefault(x => x.StudentID == 1)
                .MTMCourses.Add(WCFCourse);
            employeeDBContext.SaveChanges();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            EmployeeDBContext employeeDBContext = new EmployeeDBContext();
            MTMCours SQLServerCourse = employeeDBContext.MTMCourses
                .FirstOrDefault(x => x.CourseID == 3);

            employeeDBContext.MTMStudents.FirstOrDefault(x => x.StudentID == 2)
                .MTMCourses.Remove(SQLServerCourse);
            employeeDBContext.SaveChanges();
        }
    }
}