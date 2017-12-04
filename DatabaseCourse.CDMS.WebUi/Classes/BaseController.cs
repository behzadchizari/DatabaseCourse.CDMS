using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using DatabaseCourse.Common.Enums;

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
                var hasAccess = false;
                var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                var actionName = filterContext.ActionDescriptor.ActionName;
                //Get Security Config by Controller/Action
                var security = SecutiryConfig.GetConfigByPageName($@"/{controllerName}/{actionName}");
                if (security != null)
                {
                    ThisApp.PageTitle = security.PageName;
                    ThisApp.PageDesctiption= security.PageDescription;

                    //check user from this app 
                    foreach (var userRole in security.UserRoleList)
                    {
                        //check role of user with page permission   
                        if ((ThisApp.CurrentUser == null && userRole == UserRoleEnum.Guest ) || userRole == UserRoleEnum.All) return null;
                        var loginedUser = ThisApp.CurrentUser;
                        if (loginedUser == null) continue;
                        hasAccess = loginedUser.UserRoles.Any(x => x == userRole || x == UserRoleEnum.SuperAdmin);
                        if (hasAccess) return null;
                    }
                }
                else
                {
                    return new Exception("دسترسی به این صفحه امکان پذیر نمیباشد.", new Exception("مورد امنیتی برای صفحه‌ی مورد نظر یافت نشد.")); ;
                }
                return hasAccess ? null : new Exception("دسترسی به این صفحه امکان پذیر نمیباشد.");
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        #endregion

    }

}