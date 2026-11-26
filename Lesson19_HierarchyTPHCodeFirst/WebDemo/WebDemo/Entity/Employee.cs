using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDemo.Entity
{
    public abstract class Employee
    {
        [Column(Order = 1)]
        public int ID { get; set; }
        [Column(Order = 2)]
        public string FirstName { get; set; }
        [Column(Order = 3)]
        public string LastName { get; set; }
        [Column(Order = 4)]
        public string Gender { get; set; }
    }
}