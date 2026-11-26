using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
using System.Text;

namespace Standard2
{
    public partial class Default : System.Web.UI.Page
    {
        private ListItem li;

        public DataTable getStudentDataSet()
        {
            if (ViewState["StudentDataSet"] == null)
            {
                return Student.getStudentDataSet();
            }
            else
            {
                return (DataTable)ViewState["StudentDataSet"];
            }
        }

        public DataTable getClassDataSet()
        {
            if (ViewState["ClassDataSet"] == null)
            {
                return ComputerClass.getComputerClassDataSet();
            }
            else
            {
                return (DataTable)ViewState["ClassDataSet"];
            }
        }

        public DataTable getTeacherDataSet()
        {
            if (ViewState["TeacherDataSet"] == null)
            {
                return Teacher.getTeacherDataSet();
            }
            else
            {
                return (DataTable)ViewState["TeacherDataSet"];
            }
        }

        public DataTable getStudentClassDataSet()
        {
            if (ViewState["StudentClassDataSet"] == null)
            {
                return Student_Class.getStudent_ClassDataSet();
            }
            else
            {
                return (DataTable)ViewState["StudentClassDataSet"];
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    ini();
                }
            }


        }

        protected void ini()
        {
            Control searchbutton = search.FindControl("btn"); searchbutton.Visible = false;

            gvClass.DataSource = getClassDataSet();
            gvClass.DataBind();
            gvTeacher.DataSource = getTeacherDataSet();
            gvTeacher.DataBind();
            gvStudent.DataSource = getStudentDataSet();
            gvStudent.DataBind();
            gvStudentClass.DataSource = getStudentClassDataSet();
            gvStudentClass.DataBind();

            DataTable ClassDT = getClassDataSet();
            DataTable StudentDT = getStudentDataSet();


            li = new ListItem();
            li.Text = "Select Class";
            ddlClass.Items.Add(li);
            for (int i = 0; i < ClassDT.Rows.Count; i++)
            {
                li = new ListItem();
                li.Value = ClassDT.Rows[i]["classid"].ToString();
                li.Text = ClassDT.Rows[i]["classname"].ToString();
                ddlClass.Items.Add(li);
            }

            li = new ListItem();
            li.Text = "Select Student";
            ddlStudent.Items.Add(li);
            for (int i = 0; i < StudentDT.Rows.Count; i++)
            {
                li = new ListItem();
                li.Value = StudentDT.Rows[i]["studentid"].ToString();
                li.Text = StudentDT.Rows[i]["studentname"].ToString();
                ddlStudent.Items.Add(li);
            }

            List<Student_Class> sccollection = Student_Class.getRegistrationInfo();
            var result = from items in sccollection
                         group new { items.ClassID, items.StudentID }
                         by new { items.ClassID }
                             into grouppedItems
                             select new
                             {
                                 status = grouppedItems.Key,
                                 values = grouppedItems
                             };

            int count = 0; int classid = 0; TI ti; List<TI> ticollection = new List<TI>();
            foreach(var group in result)
            {
                ti = new TI();
                foreach(var item in group.values)
                {
                    classid = item.ClassID;
                    count++;
                }
                ti.classid = classid; ti.num = count;
                ticollection.Add(ti);
                count = 0;
            }

            gvTI.DataSource = ticollection;
            gvTI.DataBind();
        }

        public class TI
        {
            public int num { set; get; }
            public int classid { set; get; }
        }

        protected void btnAddRegistration_Click(object sender, EventArgs e)
        {
            Student_Class.register(Config.ConvertToInt(ddlStudent.SelectedValue), Config.ConvertToInt(ddlClass.SelectedValue));
            ini();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetAllowResponseInBrowserHistory(false);
            Session.RemoveAll();

            Response.Redirect(FormsAuthentication.LoginUrl);
        }

        protected void btnGeneratePage_Click(object sender, EventArgs e)
        {
            String title = "This is the title";
            String Message = "This is the message.";
            Message = Message.Replace("\n", "<br />");
            String Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            String FileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".html";

            String HtmlPath = String.Format(@"\Html\{0}", FileName);
            String HtmlTemp = System.IO.File.ReadAllText(Server.MapPath(".") +@"\Html\HtmlTemp.html", System.Text.Encoding.UTF8);
            StringBuilder SBuilder = new StringBuilder(HtmlTemp);
            SBuilder.Replace("{Title}", title);
            SBuilder.Replace("{AddMsg}", Message);

            System.IO.StreamWriter SWriter = System.IO.File.CreateText(Server.MapPath(".") + @"\Html\" + FileName);
            SWriter.WriteLine(SBuilder.ToString());
            SWriter.Flush();
            SWriter.Close();
            Response.Redirect(HtmlPath);
        }
    }
}