using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using DatabaseCourse.Common.Enums;
using DatabaseCourse.Common.Utility.EnumUtility;
using DatabaseCourse.CDMS.Business.BusinessModel;
using DatabaseCourse.CDMS.Business.BusinessLogic;

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
            ThisApp.AddExceptionData(filterContext.Exception);
        }

        #endregion

        #region Helper
     

        private Exception CheckPermission(ActionExecutingContext filterContext)
        {
            try
            {
                var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                var actionName = filterContext.ActionDescriptor.ActionName;
                actionName = actionName[0].ToString().ToUpper() + actionName.Substring(1, actionName.Length - 1);
                controllerName = controllerName[0].ToString().ToUpper() + controllerName.Substring(1, controllerName.Length - 1);
                //Get Security Config by Controller/Action
                return AccessHelper.HasAccessToAction(controllerName, actionName,null,true);
            }
            catch (Exception ex)
            {
                return ex;
            }
        }



        #endregion

    }

}