using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using DatabaseCourse.Common.Enums;
using DatabaseCourse.Common.Utility.EnumUtility;

namespace DatabaseCourse.CDMS.WebUi.Classes
{
    public abstract class BaseController : Controller
    {
        #region Abstract Methods

        protected abstract void SetSessionAndViewBags();
        protected abstract void LoadSessionAndViewBags();
        protected abstract Exception InnerSecurityCheck();


        #endregion

        #region Override Methods

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LoadSessionAndViewBags();
            ThisApp.AccessDenied = CheckPermission(filterContext);
            ThisApp.InnerAccessDenied = InnerSecurityCheck();
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            SetSessionAndViewBags();
        }

        protected override void OnException(ExceptionContext filterContext)
        {

        }

        #endregion

        #region Helper

        private Exception CheckPermission(ActionExecutingContext filterContext)
        {
            try
            {
                var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                var actionName = filterContext.ActionDescriptor.ActionName;
                actionName = actionName[0].ToString().ToUpper()  + actionName.Substring(1,actionName.Length-1);
                controllerName = controllerName[0].ToString().ToUpper()  + controllerName.Substring(1, controllerName.Length-1);
                //Get Security Config by Controller/Action
                var security = SecutiryConfig.GetConfigByPageName($@"/{controllerName}/{actionName}");
                if (security != null)
                {
                    ThisApp.PageTitle = security.PageName;
                    ThisApp.PageDesctiption = security.PageDescription;

                    var loginedUser = ThisApp.CurrentUser;
                    if (loginedUser != null && controllerName == "Login" && actionName == "Index")
                    {
                        ThisApp.AccessDeniedType = AccessDeniedType.UserLogined;
                        return new Exception(EnumUtility.GetEnumDescription(AccessDeniedType.UserLogined));
                    }
                    //check user from this app 
                    foreach (var userRole in security.UserRoleList)
                    {
                        //check role of user with page permission   
                        if ((ThisApp.CurrentUser == null && userRole == UserRoleEnum.Guest) || userRole == UserRoleEnum.All)
                        {
                            ThisApp.AccessDeniedType = AccessDeniedType.Null;
                            return null;
                        }
                        if (loginedUser == null)
                        {
                            ThisApp.AccessDeniedType = AccessDeniedType.NotLogined;
                            return new Exception(EnumUtility.GetEnumDescription(AccessDeniedType.NotLogined));
                        }
                        if (!loginedUser.UserRoles.Any(x => x == userRole || x == UserRoleEnum.SuperAdmin)) continue;
                        ThisApp.AccessDeniedType = AccessDeniedType.Null;
                        return null;
                    }
                }
                else
                {
                    ThisApp.AccessDeniedType = AccessDeniedType.NoSecurityConfig;
                    return new Exception("دسترسی به این صفحه امکان پذیر نمیباشد.", new Exception("مورد امنیتی برای صفحه‌ی مورد نظر یافت نشد.")); ;
                }
                ThisApp.AccessDeniedType = AccessDeniedType.NoAccessToPage;
                return new Exception("دسترسی به این صفحه امکان پذیر نمیباشد.");
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        #endregion

    }

}