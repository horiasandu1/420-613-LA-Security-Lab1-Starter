using SecurityLab1_Starter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SecurityLab1_Starter
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error()
        {

            var ex = Server.GetLastError();

            LogUtil lu = new LogUtil();
            lu.LogToEventViewer(System.Diagnostics.EventLogEntryType.Error, ex.Message);

            Exception exception = Server.GetLastError();

            StreamWriter w = new StreamWriter("C:\\Temp\\log.txt", true);
            String message = exception.Message.ToString();
                //File.AppendText("C:\\Temp\\log.txt",true))
            
            lu.Log(message, w);

            w.Close();
            
        }
    }
}
