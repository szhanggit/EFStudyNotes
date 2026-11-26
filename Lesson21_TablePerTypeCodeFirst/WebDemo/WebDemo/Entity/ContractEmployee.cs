using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDemo.Entity
{
    [Table("ContractEmployees")]
    public class ContractEmployee : Employee
    {
        public int HoursWorked { get; set; }
        public int HourlyPay { get; set; }
    }
}