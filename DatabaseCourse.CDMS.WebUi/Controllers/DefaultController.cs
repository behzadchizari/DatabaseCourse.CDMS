using DatabaseCourse.CDMS.WebUi.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseCourse.CDMS.WebUi.Controllers
{
    public class DefaultController : BaseController
    {
        // GET: Default
        public ActionResult Index()
        {
            var x = 2 / (1-Math.Abs(-1));
            return View();
        }
    }
}