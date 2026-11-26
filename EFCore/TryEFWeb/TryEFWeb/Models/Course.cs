using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TryEFWeb.Models
{
    [Table("Class")]
    public class Course
    {
        [Column("classid")]
        public int Id { get; set; }
        [Column("classname")]
        public string ClassName { get; set; }
        [Column("credit")]
        public int Credit { get; set; }
        [Column("startdate")]
        public DateTime StartDate { get; set; }
        [Column("enddate")]
        public DateTime EndDate { get; set; }
        public Teacher Teacher { get; set; }
        public IEnumerable<StudentCourse> StudentCourses { get; set; }
    }
}
