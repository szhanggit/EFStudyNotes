using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TryEFWeb.Models
{
    [Table("student_class")]
    public class StudentCourse
    {
        [Column("student_classid")]
        public int Id { get; set; }

        [Column("studentid")]
        public int StudentId { get; set; }
        [Column("classid")]
        public int CourseId { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
