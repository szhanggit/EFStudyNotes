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
            GridView1.DataSource = employeeDBContext.SRDEmployees.Select(emp => new
            {
                EmployeeName = emp.EmployeeName,
                ManagerName = emp.Manager == null ? "Super Boss"
                                : emp.Manager.EmployeeName
            }).ToList();
            GridView1.DataBind();
        }
    }
}