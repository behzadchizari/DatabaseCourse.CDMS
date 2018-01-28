using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using DatabaseCourse.CDMS.Business.BusinessLogic;
using DatabaseCourse.CDMS.WebUi.Classes;

namespace DatabaseCourse.CDMS.WebUi.Controllers
{
    public class LeaveController : BaseController
    {
        // GET: Leave
        public ActionResult Index(int cid)
        {
            if (cid != 0)
            {
                var cooBll = new CooperationContractBll();
                var cooInfo = cooBll.GetCooperationContractInfosByContractorId(cid).Where(x=>x.EndDate == null).ToList();
                ViewBag.CooperationData = cooInfo;
                if (!cooInfo.Any())
                {
                    Session["ContractorEditResultMessage"] = "پیمانکار در هیچ پروژه ای مشغول نیست.";
                    return RedirectToAction("Index", "Contractor");
                }
            }
            return View();
        }

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
    }
}