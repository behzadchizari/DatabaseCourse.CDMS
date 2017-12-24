using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using DatabaseCourse.CDMS.Business.BusinessLogic;
using DatabaseCourse.CDMS.WebUi.Classes;
using DatabaseCourse.Common.Enums;
using DatabaseCourse.Common.Utility;
using DatabaseCourse.Common.Utility.EnumUtility;

namespace DatabaseCourse.CDMS.WebUi.Controllers
{
    public class LoginController : BaseController
    {
        #region Variables

        private int _loginUserId;

        #endregion

        #region Action Methods
        public ActionResult Index()
        {
            if (ThisApp.CurrentUser != null)
                RedirectToAction("Index", "Default");
            return View();
        }

        public JsonResult Login(string userName, string password)
        {
            var json = new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            try
            {
                if (ThisApp.AccessDenied != null ||
                    ThisApp.InnerAccessDenied != null)
                {
                    json.Data = new
                    {
                        Status = JsonResultStatus.AccessDenied,
                        Description = ExceptionUtility.GetAllInnerException(ThisApp.AccessDenied ?? ThisApp.InnerAccessDenied)
                    };
                    return json;
                }
                if (ThisApp.CurrentUser != null)
                {
                    json.Data = new
                    {
                        Status = JsonResultStatus.AlreadyLogedIn,
                        Description = EnumUtility.GetEnumDescription(JsonResultStatus.AlreadyLogedIn)
                    };
                    return json;
                }
                var userBll = new UserBLL(ThisApp.CurrentUser);
                var user = userBll.GetUserInfoByUserNameAndPassword(userName, password);
                if (user != null)
                {
                    ThisApp.AddLogData($"ورود به سامانه - کاربر {user.Username}");
                    _loginUserId = user.Id;
                    json.Data = new
                    {
                        Status = JsonResultStatus.Ok
                    };
                    //RedirectToAction("Index", "Default");
                    //Redirect("/DefaultIndex/");
                }
                else
                {
                    json.Data = new
                    {
                        Status = JsonResultStatus.UserNotFound,
                        Description = "کاربر یافت نشد."
                    };
                }
            }
            catch (Exception ex)
            {
                json.Data = new
                {
                    Status = JsonResultStatus.Exception,
                    Description = ExceptionUtility.GetAllInnerException(ex)
                };
            }
            return json;
        }

        public ActionResult logout()
        {
            ThisApp.AddLogData($"خروج از سامانه - کاربر {ThisApp.CurrentUser?.Username??""}");
            Session["UserId"] = null;
            return View("Index");
        }


        #endregion

        #region Abstract Methods


        protected override void SetSessionAndViewBags()
        {
            Session["UserId"] = _loginUserId;
        }

        protected override void LoadSessionAndViewBags()
        {

        }

        protected override Exception InnerSecurityCheck()
        {
            return null;
        }

        #endregion

        #region Helper

        private void MakeDefault()
        {
            _loginUserId = 0;
        }

        #endregion
    }
}