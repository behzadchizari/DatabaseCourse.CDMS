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
            Update = 20,
            Delete = 30,
        }

        #endregion

        #region Action Methods

        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult ResetPassword(int id = 0)
        {
            ThisApp.Session["UserId"] = id;
           
            if (id != 0)
            {
                var userInfo = UserBll.GetUserInfoById(id);
                if (userInfo == null && ThisApp.HasAccessToView("User","Index"))
                {
                    Session["UserEditResultMessage"] = "کاربر یافت نشد.";
                    return View("Index");
                }

            }
            return View();
        }

        [HttpPost]
        public JsonResult EditPassword(string password)
        {
            Session["UserEditResultMessage"] = null;
            var UserId = 0;
            var result = new JsonResult();
            try
            {
                if (ThisApp.AccessDeniedType == AccessDeniedType.NoAccessToPage)
                { result.Data = ThisApp.AccessDenied.Message ?? ThisApp.InnerAccessDenied.Message ?? ""; return result; }
                if (string.IsNullOrEmpty(password) || password.Length < 3)
                {
                    result.Data = new
                    {
                        Status = JsonResultStatus.Exception,
                        Description = new List<Exception>() { new Exception("رمز عبور وارد شده معتبر نیست - طول رمزعبور باید بیشتر از 3 باشد") }
                    };
                    return result;
                }
                UserId = (ThisApp.Session["UserId"] != null) ? (int)ThisApp.Session["UserId"] : 0;

                if (UserId != 0)
                {
                    var user = UserBll.GetUserInfoById(UserId);
                    var userEdit = UserBll.UpdateExistingUserInfor(new UserInfo()
                    {
                        Password = password,
                        Id = UserId,
                    });

                    if (userEdit == null)
                    {
                        Session["UserEditResultMessage"] = $"رمزعبور کاربر { user.Username} با موفقیت <span style=\"color: blue; \" > تغییر </span> یافت";
                        ThisApp.AddLogData($"بازیابی رمزعبور کاربر {user.Username} توسط {ThisApp.CurrentUser.Username}");
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
                            Description = new List<Exception>() { userEdit }
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

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            ThisApp.Session["UserId"] = id;
            if(id != 0)
            {
                var userInfo = UserBll.GetUserInfoById(id);
                if(userInfo == null)
                {
                    Session["UserEditResultMessage"] = "کاربر یافت نشد.";
                    return View("Index");
                }

            }
            return View();
        }

        [HttpPost]
        public JsonResult UserEdit(EditUserFunctionEnum fn, UserUiModel userUiModel)
        {
            Session["UserEditResultMessage"] = null;
            var UserId = 0;
            var result = new JsonResult();
            try
            {
                if (ThisApp.AccessDeniedType == AccessDeniedType.NoAccessToPage)
                { result.Data = ThisApp.AccessDenied.Message ?? ThisApp.InnerAccessDenied.Message ?? ""; return result; }
                if (fn != EditUserFunctionEnum.Delete)
                {
                    UserId = (ThisApp.Session["UserId"] != null) ? (int)ThisApp.Session["UserId"] : 0;
                    userUiModel.Id = UserId;

                    var checkData = userUiModel.ChackModel(fn);
                    if (checkData.Count > 0)
                    { 
                        result.Data = new
                        {
                            Status = JsonResultStatus.Exception,
                            Description = checkData
                        };
                        return result;
                    }
                }
                switch (fn)
                {
                    case EditUserFunctionEnum.Delete:
                        {
                            var userInfo = UserBll.GetUserInfoById(userUiModel.Id);
                            var deleteUser = UserBll.RemoveUser(userInfo.Id);
                            if (deleteUser == null)
                            {
                                Session["UserEditResultMessage"] =$"کاربر {userInfo.Username} با موفقیت <span style=\"color: red; \" > حذف </span> شد.";
                                ThisApp.AddLogData($"حذف کاربر {userInfo.Username} توسط {ThisApp.CurrentUser.Username}");
                                result.Data = new
                                {
                                    Status = JsonResultStatus.Ok,
                                };
                            }
                            else
                            {
                                Session["UserEditResultMessage"] = $"کاربر { userInfo.Username} حذف نشد.";
                                result.Data = new
                                {
                                    Status = JsonResultStatus.Exception,
                                    Description = new List<Exception>() { deleteUser }
                                };
                            }
                            break;
                        }
                    case EditUserFunctionEnum.Add:
                        {
                            var userAdd = UserBll.AddNewUserInfo(new UserInfo()
                            {
                                Username = userUiModel.Username,
                                Password = userUiModel.Password,
                                UserRoles = userUiModel.UserRoles,
                                FirstName = userUiModel.FirstName,
                                LastName = userUiModel.LastName
                            });
                            if (userAdd == null)
                            {
                                Session["UserEditResultMessage"] = $"کاربر { userUiModel.Username} با موفقیت <span style=\"color: green; \" > درج </span> شد";
                                ThisApp.AddLogData($"درج کاربر {userUiModel.Username} توسط {ThisApp.CurrentUser.Username}");
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
                            break;
                        }
                    case EditUserFunctionEnum.Update:
                        {
                            if (UserId != 0)
                            {
                                var userEdit = UserBll.UpdateExistingUserInfor(new UserInfo()
                                {
                                    Username = userUiModel.Username,
                                    UserRoles = userUiModel.UserRoles,
                                    FirstName = userUiModel.FirstName,
                                    LastName = userUiModel.LastName,
                                    Id = UserId
                                });

                                if (userEdit == null)
                                {
                                    Session["UserEditResultMessage"] = $"کاربر { userUiModel.Username} با موفقیت <span style=\"color: blue; \" > تغییر </span> یافت";
                                    ThisApp.AddLogData($"به روز رسانی کاربر {userUiModel.Username} توسط {ThisApp.CurrentUser.Username}");
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
                                        Description = new List<Exception>() { userEdit }
                                    };
                                }
                            }
                            else
                            {
                                result.Data = new
                                {
                                    Status = JsonResultStatus.Exception,
                                    Description = new List<Exception>() { new Exception("داده‌ای برای نمایش یافت نشد") }
                                };
                            }
                            break;
                        }
                    default:
                        break;
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