using DatabaseCourse.CDMS.Business.Business_Logic;
using DatabaseCourse.CDMS.Business.Business_Model;
using DatabaseCourse.CDMS.WebUi.Classes;
using DatabaseCourse.Common.Enums;
using DatabaseCourse.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseCourse.CDMS.WebUi.Controllers.Test
{
    public class BehzadTestController : Controller
    {
        // GET: BehzadTest
        public ActionResult Index()
        {
            var userBll = new UserBLL(ThisApp.CurrentUser);
            var e = userBll.AddNewUserInfo(new UserInfo()
            {
                Username = "Admin",
                Password = "123",
                UserRoles = new List<Common.Enums.UserRoleEnum> { UserRoleEnum.Admin },

            });
            if (e != null)
                ViewBag.IsOk = ExceptionUtility.GetAllInnerException(e);
            else
                ViewBag.IsOk = "Ok";
            return View();
        }
    }
}