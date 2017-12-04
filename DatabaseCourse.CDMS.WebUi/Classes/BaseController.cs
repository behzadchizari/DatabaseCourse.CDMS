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

        protected abstract void SetSessionAndViewBag();

        #endregion
        #region Override Methods

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var hasAccess = CheckPermission(filterContext);
            switch (hasAccess)
            {
                case true:
                    ThisApp.AccessDenied = null;
                    break;
                case false:
                    ThisApp.AccessDenied = new Exception("دسترسی به این صفحه امکان پذیر نمیباشد.");
                    break;
                case null:
                    ThisApp.AccessDenied = new Exception("دسترسی به این صفحه امکان پذیر نمیباشد.", new Exception("مورد امنیتی برای صفحه‌ی مورد نظر یافت نشد."));
                    break;
            }
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var fil = filterContext;
            SetSessionAndViewBag();

        }

        protected override void OnException(ExceptionContext filterContext)
        {
            var fil = filterContext;
        }

        #endregion

        #region Helper

        private bool? CheckPermission(ActionExecutingContext filterContext)
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

                    //check user from this app 
                    foreach (var userRole in security.UserRoleList)
                    {
                        //check role of user with page permission   
                        if (ThisApp.CurrentUser == null && userRole == UserRoleEnum.Guest) return true;
                    }
                }
                else
                {
                    return null;
                }
                return hasAccess;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

    }

}