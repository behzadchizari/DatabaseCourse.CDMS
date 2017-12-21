using DatabaseCourse.CDMS.WebUi.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseCourse.CDMS.WebUi.Controllers
{
    public class EventController : BaseController
    {
        // GET: Event
        public ActionResult Index()
        {
            return View();
        }

        protected override Exception InnerSecurityCheck()
        {
            return null;
        }

        protected override void LoadSessionAndViewBags()
        {
        }

        protected override void SetSessionAndViewBags()
        {
        }
    }
}