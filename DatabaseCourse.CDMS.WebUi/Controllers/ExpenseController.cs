using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseCourse.CDMS.WebUi.Classes;

namespace DatabaseCourse.CDMS.WebUi.Controllers
{
    public class ExpenseController : BaseController
    {
        // GET: Expense
        public ActionResult Index()
        {
            return View();
        }

        protected override void SetSessionAndViewBags()
        {
        }

        protected override void LoadSessionAndViewBags()
        {
        }

        protected override Exception InnerSecurityCheck()
        {
            return null;
        }
    }
}