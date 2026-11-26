using EFDemo.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace EFDemo
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Here, we are telling the entity framework to drop 
            //and recreate database every time the model changes.
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EmployeeDBContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<EmployeeDBContext>());
        }
    }
}