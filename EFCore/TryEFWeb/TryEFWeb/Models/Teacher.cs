using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TryEFWeb.Models
{
    [Table("teacher")]
    public class Teacher
    {
        [Column("teacherid")]
        public int Id { get; set; }
        [Column("teachername")]
        public string TeacherName { get; set; }
        [Column("gender")]
        public int Gender { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}
