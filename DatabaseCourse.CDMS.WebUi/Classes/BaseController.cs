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
            var fil = filterContext;
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

    }

}