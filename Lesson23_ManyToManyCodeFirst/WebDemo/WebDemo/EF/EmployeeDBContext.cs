using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebDemo.Entity;

namespace WebDemo.EF
{
    public class EmployeeDBContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
            .HasMany(t => t.Courses)
            .WithMany(t => t.Students)
            .Map(m =>
            {
                m.ToTable("StudentCourses");
                m.MapLeftKey("StudentID");
                m.MapRightKey("CourseID");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}