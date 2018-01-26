using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseCourse.CDMS.Business.BusinessLogic;
using DatabaseCourse.CDMS.WebUi.Classes;

namespace DatabaseCourse.CDMS.WebUi.Controllers
{
    public class AttachmentController : BaseController
    {
        private AttachmentBll _attachmentBll = new AttachmentBll();

        [HttpPost]
        public JsonResult Remove(int? id)
        {
            var result = new JsonResult();
            try
            {
                _attachmentBll.RemoveAttachmentById(id ?? 0);
            }
            catch (Exception )
            {
            }
            return result;
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