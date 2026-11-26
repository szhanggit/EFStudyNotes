using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Standard2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            FormsAuthenticationTicket tktFormAuthentication = new FormsAuthenticationTicket
                                            (
                                                1
                                                    , "username"
                                                    , DateTime.Now
                                                    , DateTime.Now.AddMinutes(120)
                                                    , false
                                                    , "role"
                                            );
            string strCookie = FormsAuthentication.Encrypt(tktFormAuthentication);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, strCookie);

            cookie.Path = FormsAuthentication.FormsCookiePath;
            Response.Cookies.Add(cookie);
            //Response.Redirect("Default.aspx");
            String a = User.Identity.Name;
            FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, true);            

        }
    }
}