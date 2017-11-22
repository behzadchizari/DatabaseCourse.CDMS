using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace DatabaseCourse.CDMS.WebUi.Classes
{
    public abstract class BaseController : Controller
    {
        #region Abstract Methods

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (CheckPermission(filterContext) == null)
            {
            }
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var fil = filterContext;

        }

        protected override void OnException(ExceptionContext filterContext)
        {
            var fil = filterContext;
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
                    //check user from this app 
                    foreach (var userRole in security.UserRoleList)
                    {
                        //check role of user with page permission   
                    }
                }
                else
                {
                    return new Exception("404 - صفحه یافت نشد!");
                }
                return hasAccess ? null : new Exception("شما اجازه دسترسی به این صفحه را ندارید");
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        #endregion

    }

}