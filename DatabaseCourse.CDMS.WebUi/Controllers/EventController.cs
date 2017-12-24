using DatabaseCourse.CDMS.WebUi.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseCourse.CDMS.Business.BusinessLogic;
using DatabaseCourse.Common.Enums;

namespace DatabaseCourse.CDMS.WebUi.Controllers
{
    public class EventController : BaseController
    {
        // GET: Event
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetLogs(LogTypeEnum type)
        {
            var result = new JsonResult() { JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            try
            {
                var logBll = new LogBLL(ThisApp.CurrentUser);
                var loglist = logBll.GetAllByType(LogTypeEnum.Log);
                result.Data = new
                {
                    Status = JsonResultStatus.Ok,
                    Data = loglist
                };
                return result;
            }
            catch (Exception e)
            {
                result.Data = new
                {
                    Status = JsonResultStatus.Exception,
                    Data = e.Message
                };
            }
            return result;
        }

        protected override Exception InnerSecurityCheck()
        {
            return null;
        }

        protected override void LoadSessionAndViewBags()
        {
        }

        protected override void SetSessionAndViewBags()
        {
        }
    }
}