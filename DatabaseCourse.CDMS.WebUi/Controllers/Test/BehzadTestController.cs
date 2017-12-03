using DatabaseCourse.CDMS.Business.BusinessLogic;
using DatabaseCourse.CDMS.Business.BusinessModel;
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
            return View();
        }
        public ActionResult Add()
        {
            var userBll = new UserBLL(ThisApp.CurrentUser);
            var e = userBll.AddNewUserInfo(new UserInfo()
            {
                Username = "Admin5",
                Password = "1234",
                UserRoles = new List<Common.Enums.UserRoleEnum> { UserRoleEnum.Admin, UserRoleEnum.CEO },

            });
            if (e != null)
                ViewBag.IsOk = ExceptionUtility.GetAllInnerException(e);
            else
                ViewBag.IsOk = "Ok";
            return View("Index");
        }
        // GET: BehzadTest
        public ActionResult Update()
        {
            var userBll = new UserBLL(ThisApp.CurrentUser);
            var us = userBll.GetUserInfoById(1);
            us.Username = "Admin2";
            var e = userBll.UpdateExistingUserInfor(us);
            if (e != null)
                ViewBag.IsOk = ExceptionUtility.GetAllInnerException(e);
            else
            { ViewBag.IsOk = "Ok"; }
            return View("Index");
        }
        // GET: BehzadTest
        public ActionResult Login(string p,string u)
        {
            var userBll = new UserBLL(ThisApp.CurrentUser);
            var e = userBll.GetUserInfoByUserNameAndPassword(u, p);
            if (e != null)
            {
                ViewBag.IsOk = "";
                foreach (var item in e.UserRoles)
                {
                    ViewBag.IsOk += item + " ";
                }
                ViewBag.IsOk += e.Username;
                var er = e.UserRoles;

            }
            else
                ViewBag.IsOk = "NOk";
            return View("Index");
        }


    }
}