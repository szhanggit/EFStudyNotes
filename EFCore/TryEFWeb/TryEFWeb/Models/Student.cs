using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TryEFWeb.Models
{
    [Table("Student")]
    public class Student
    {
        [Column("studentid")]
        public int Id { get; set; }
        [Column("studentname")]
        public string StudentName { get; set; }
        [Column("gender")]
        public int Gender { get; set; }
        public IEnumerable<StudentCourse> StudentCourses { get; set; }
    }
}
