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

            GridView1.DataSource = (from student in employeeDBContext.BridgeStudents
                                    from studentCourse in student.BridgeStudentCourses
                                    select new
                                    {
                                        StudentName = student.StudentName,
                                        CourseName = studentCourse.BridgeCours.CourseName,
                                        EnrolledDate = studentCourse.EnrolledDate
                                    }).ToList();

            // The above query can also be written as shown below
            //GridView1.DataSource = (from course in employeeDBContext.Courses
            //                        from studentCourse in course.StudentCourses
            //                        select new
            //                        {
            //                            StudentName = studentCourse.Student.StudentName,
            //                            CourseName = course.CourseName,
            //                            EnrolledDate = studentCourse.EnrolledDate
            //                        }).ToList();

            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EmployeeDBContext employeeDBContext = new EmployeeDBContext();
            employeeDBContext.BridgeStudentCourses.Add
                (new BridgeStudentCours
                {
                    StudentID = 1,
                    CourseID = 4,
                    EnrolledDate = DateTime.Now
                });
            employeeDBContext.SaveChanges();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            EmployeeDBContext employeeDBContext = new EmployeeDBContext();
            BridgeStudentCours studentCourseToRemove = employeeDBContext.BridgeStudentCourses
                .FirstOrDefault(x => x.StudentID == 2 && x.CourseID == 3);
            employeeDBContext.BridgeStudentCourses.Remove(studentCourseToRemove);
            employeeDBContext.SaveChanges();
        }
    }
}