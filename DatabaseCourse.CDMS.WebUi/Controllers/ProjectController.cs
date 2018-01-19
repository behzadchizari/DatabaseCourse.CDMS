using DatabaseCourse.CDMS.Business.BusinessLogic;
using DatabaseCourse.CDMS.WebUi.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseCourse.CDMS.WebUi.Controllers
{
    public class ProjectController : BaseController
    {
        #region Variables

        ProjectBll projectBll = new ProjectBll(ThisApp.CurrentUser);

        #endregion

        #region Action Methds
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            ThisApp.Session["ProjectId"] = id;
            if (id != 0)
            {
                var userInfo = projectBll.GetByProjectId(id);
                if (userInfo == null)
                {
                    Session["ProjectEditResultMessage"] = "پروژه یافت نشد.";
                    return View("Index");
                }

            }
            return View();
        }

        #endregion

        #region Abstract Methods
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
        #endregion

        #region Helper Methods

        #endregion

    }
}