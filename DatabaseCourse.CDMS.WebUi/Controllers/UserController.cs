using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using DatabaseCourse.CDMS.Business.BusinessLogic;
using DatabaseCourse.CDMS.Business.BusinessModel;
using DatabaseCourse.CDMS.WebUi.Classes;
using DatabaseCourse.CDMS.WebUi.Classes.UiModel;
using DatabaseCourse.Common.Enums;
using DatabaseCourse.Common.Utility.EnumUtility;

namespace DatabaseCourse.CDMS.WebUi.Controllers
{
    public class UserController : BaseController
    {
        #region variables

        readonly UserBLL UserBll = new UserBLL(ThisApp.CurrentUser);
        public enum EditUserFunctionEnum
        {
            Null = 0,
            Add = 10,
            Update = 20
        }

        #endregion

        #region Action Methods

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public JsonResult UserEdit(EditUserFunctionEnum fn, UserUiModel userUiModel)
        {
            Session["UserEditResultMessage"] = null;
            var result = new JsonResult();
            try
            {
                var checkData = userUiModel.ChackModel();
                if (checkData.Count > 0)
                {
                    result.Data = new
                    {
                        Status = JsonResultStatus.Exception,
                        Description = checkData
                    };
                }
                else
                {
                    var userAdd = UserBll.AddNewUserInfo(new UserInfo()
                    {
                        Username = userUiModel.Username,
                        Password = userUiModel.Password,
                        UserRoles = userUiModel.UserRoles
                    });
                    if (userAdd == null)
                    {
                        Session["UserEditResultMessage"] = $"کاربر { userUiModel.Username} با موفقیت اضافه شد";
                        result.Data = new
                        {
                            Status = JsonResultStatus.Ok,
                        };
                    }
                    else
                    {
                        result.Data = new
                        {
                            Status = JsonResultStatus.Exception,
                            Description = new List<Exception>() { userAdd }
                        };
                    }
                }
            }
            catch (Exception e)
            {
                result.Data = new
                {
                    Status = JsonResultStatus.Exception,
                    Description = new List<Exception>() { e }
                };
            }
            return result;
        }

        #endregion

        #region Abstract Methods


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

        #endregion

        #region Helper Methods


        #endregion


    }
}