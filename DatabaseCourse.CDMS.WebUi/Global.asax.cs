using DatabaseCourse.CDMS.DataAccess.Classes;
using DatabaseCourse.CDMS.WebUi.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DatabaseCourse.CDMS.WebUi
{
    public class MvcApplication : System.Web.HttpApplication
    {
protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var UserInit = new DataAccess.Classes.UserConfigTransfer(new Classes.UserConfigTransfer());

            //Create Attachment Dir
            var path = ThisApp.BaseDirectory+ "Attachments";
            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
                di.Attributes = FileAttributes.Directory |
                    FileAttributes.Hidden |
                    FileAttributes.System |
                    FileAttributes.Archive;
            }
            //
        }

    }
}
