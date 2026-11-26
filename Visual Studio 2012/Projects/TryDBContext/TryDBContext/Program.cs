using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryDBContext
{
    class Program
    {
        static void Main(string[] args)
        {
            //ShowStudents(); //ShowTeachers(); //ShowClasses(); //ShowRegistration();
            //FindAStudent(1);
            //FindATeacher(1);
            //FindAClass(1);
            //FindARegistration(3);
            //AddNewStudent("Eric", 1);
            //AddNewTeacher("Dr. Zhang", 1);
            //AddNewClass("Database", 4, new DateTime(2016, 4, 4), new DateTime(2016, 8, 4), 1);
            //AddNewRegistration(5, 1);
            AddNewRegistrationSP(4, 4);
            //EditStudent(5, "Steven", 1);
            //EditTeacher(3, "Eng. Zhang", 1);
            //EditClass(1, "Operating System", 2, 4, new DateTime(2016, 12, 11), new DateTime(2017, 2, 1));
            //DeleteRegistration(7);
            //DeleteClass(2);
            //DeleteTeacher(1);
            //DeleteStudent(1);
        }

        private static void ShowStudents()
        {
            using (var context = new StandardEntities())
            {
                var student = from s in context.students.AsNoTracking() orderby s.studentname select s;
                foreach (var item in student)
                {
                    Console.WriteLine(item.studentname);
                }
                Console.ReadLine();

            }        
        }

        private static void ShowTeachers()
        {
            using (var context = new StandardEntities())
            {
                var teacher = from t in context.teachers.AsNoTracking() orderby t.teachername select t;
                foreach (var item in teacher)
                {
                    Console.WriteLine(item.teachername);
                }
                Console.ReadLine();
            }
        }

        private static void ShowClasses()
        {
            using (var context = new StandardEntities())
            {
                var classes = from c in context.Classes.AsNoTracking() orderby c.classid select c;
                foreach (var item in classes)
                {
                    Console.WriteLine(item.classname);
                }
                Console.ReadLine();
            }            
        }

        private static void ShowRegistration()
        {
            using (var context = new StandardEntities())
            {
                var registration = from sc in context.student_class.AsNoTracking() orderby sc.student_classid select sc;
                foreach (var item in registration)
                {
                    Console.WriteLine(item.student_classid);
                }
                Console.ReadLine();
            }
        }

        private static student FindAStudent(int studentid)
        { 
            student student = new student();
            using (var context = new StandardEntities())
            {
                student = context.students.Find(studentid);
            }

            return student;
        }

        private static teacher FindATeacher(int teacherid)
        {
            teacher teacher = new teacher();
            using (var context = new StandardEntities())
            {
                teacher = context.teachers.Find(teacherid);//Its class object will not be returned.
            }

            return teacher;
        }

        private static Class FindAClass(int classid)
        {
            Class searchedclass = new Class();
            using (var context = new StandardEntities())
            {
                searchedclass = context.Classes.Find(classid);
            }

            return searchedclass;
        }

        private static student_class FindARegistration(int regid)
        {
            student_class registration = new student_class();
            using (var context = new StandardEntities())
            {
                registration = context.student_class.Find(regid);
            }

            return registration;
        }

        private static void AddNewStudent(String name, int gender)
        {
            using (var context = new StandardEntities())
            {
                var stu = new student
                {
                    studentname = name,
                    gender = gender
                };

                var student = context.students.Find(stu.studentid) ?? context.students.Add(stu);
                context.SaveChanges();
            }
        }

        private static void AddNewTeacher(String name, int gender)
        {
            using (var context = new StandardEntities())
            {
                var tea = new teacher
                {
                    teachername = name,
                    gender = gender
                };

                var teacher = context.teachers.Find(tea.teacherid) ?? context.teachers.Add(tea);
                context.SaveChanges();
            }
        }

        private static void AddNewClass(String name, int credit, DateTime startdate, DateTime enddate, int teacherid)
        {
            if(FindATeacher(teacherid) != null)
            {
                using (var context = new StandardEntities())
                {
                    var cla = new Class
                    {
                        classname = name,
                        credit = credit,
                        startdate = startdate,
                        enddate = enddate,
                        teacherid = teacherid
                    };

                    var aclass = context.Classes.Find(cla.classid) ?? context.Classes.Add(cla);
                    context.SaveChanges();
                }           
            }
        }

        private static void AddNewRegistration(int classid, int studentid)
        {
            if (FindAClass(classid) != null && FindAStudent(studentid) != null)
            {
                using (var context = new StandardEntities())
                {
                    var reg = new student_class
                    {
                        classid = classid,
                        studentid = studentid
                    };

                    var aclass = context.student_class.Find(reg.student_classid) ?? context.student_class.Add(reg);
                    context.SaveChanges();
                }                      
            }
        }

        /*SET XACT_ABORT ON
            SET NoCount ON
            Begin Try 
                 BEGIN TRANSACTION 
                    //Insert ,update queries    
                 COMMIT
            End Try 
            Begin Catch 
                 ROLLBACK
            End Catch
         
         
         
System.Data.Entity.Core.Objects.ObjectParameter
System.Data.Objects.ObjectParameter
         
         http://www.entityframeworktutorial.net/EntityFramework4.3/execute-stored-procedure-using-dbcontext.aspx*/
        private static void AddNewRegistrationSP(int studentid, int classid)
        {
            System.Data.Entity.Core.Objects.ObjectParameter clastu = new System.Data.Entity.Core.Objects.ObjectParameter("student_classid", 0);
            int class_studentid = 0;

            if (FindAClass(classid) != null && FindAStudent(studentid) != null)
            {
                using (var context = new StandardEntities())
                {
                    class_studentid = context.createsc(clastu, studentid, classid);
                    String asdf = clastu.Value.ToString();
                }
            }
        }

        private static void EditStudent(int id, String name, int gender)
        {
            using (var context = new StandardEntities())
            {
                var stu = (from s in context.students where s.studentid == id select s).FirstOrDefault();
                stu.studentname = name;
                stu.gender = gender;
                context.SaveChanges();
            }
        }

        private static void EditTeacher(int id, String name, int gender)
        {
            using (var context = new StandardEntities())
            {
                var tea = (from t in context.teachers where t.teacherid == id select t).FirstOrDefault();
                tea.teachername = name;
                tea.gender = gender;
                context.SaveChanges();
            }
        }

        private static void EditClass(int id, String name, int teacherid, int credit, DateTime sDate, DateTime eDate)
        {
            if (FindATeacher(teacherid) != null)
            {
                using (var context = new StandardEntities())
                {
                    var cla = (from c in context.Classes where c.classid == id select c).FirstOrDefault();
                    cla.classname = name;
                    cla.teacherid = teacherid;
                    cla.credit = credit;
                    cla.startdate = sDate;
                    cla.enddate = eDate;
                    context.SaveChanges();
                }            
            }            
        }

        private static void DeleteRegistration(int regid)
        {
            using (var context = new StandardEntities())
            {
                var registration = (from sc in context.student_class where sc.student_classid == regid select sc).FirstOrDefault();
                context.student_class.Remove(registration);
                context.SaveChanges();
            }        
        }

        /*ObjectStateManager*/
        private static void DeleteClass(int classid)
        {
            using (var context = new StandardEntities())
            {
                //Cannot use AsNoTracking() in this case, otherwise will not be registered in ObjectStateManager.
                var student_class = (from sc in context.student_class where sc.classid == classid select sc).ToList();
                //var student_class = from sc in context.student_class where sc.classid == classid select sc;
                //The value in the student_class
                //{SELECT     [Extent1].[student_classid] AS [student_classid],     [Extent1].[studentid] AS [studentid],     [Extent1].[classid] AS [classid]    FROM [dbo].[student_class] AS [Extent1]    WHERE [Extent1].[classid] = @p__linq__0}
                               
                foreach (var item in student_class)
                {
                    context.student_class.Remove(item);
                }

                var findedclass = (from c in context.Classes where c.classid == classid select c).FirstOrDefault();
                context.Entry(findedclass).Collection(c => c.student_class).Load();

                context.Classes.Remove(findedclass);
                context.SaveChanges();
            }
        }

        private static void subDeleteClass(int classid, StandardEntities context)
        {
            var student_class = (from sc in context.student_class where sc.classid == classid select sc).ToList();

            foreach (var item in student_class)
            {
                context.student_class.Remove(item);
            }

            var findedclass = (from c in context.Classes where c.classid == classid select c).FirstOrDefault();
            context.Entry(findedclass).Collection(c => c.student_class).Load();

            context.Classes.Remove(findedclass);
        }
        
        private static void DeleteTeacher(int teacherid)
        {
            using (var context = new StandardEntities())
            {
                var findedclasses = (from cla in context.Classes where cla.teacherid == teacherid select cla).ToList();
                foreach (var item in findedclasses)
                {
                    subDeleteClass(item.classid, context);
                }

                //var tea0 = FindATeacher(teacherid);//'tea0.Classes' threw an exception of type 'System.ObjectDisposedException'

                var tea = (from t in context.teachers where t.teacherid == teacherid select t).SingleOrDefault();
                context.teachers.Remove(tea);
                context.SaveChanges();
            }
        }

        private static void DeleteStudent(int studentid)
        { 
            using(var context = new StandardEntities())
            {
                var student_class = (from sc in context.student_class where sc.studentid == studentid select sc).ToList();
                foreach (var item in student_class)
                {
                    context.student_class.Remove(item);
                }
                var stu = (from s in context.students where s.studentid == studentid select s).SingleOrDefault();
                context.students.Remove(stu);
                context.SaveChanges();
            }
        }
    }
}
