using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseCourse.CDMS.Business.BusinessLogic;
using DatabaseCourse.CDMS.Business.BusinessModel;
using DatabaseCourse.CDMS.WebUi.Classes;
using DatabaseCourse.CDMS.WebUi.Classes.UiModel;
using DatabaseCourse.Common.Enums;

namespace DatabaseCourse.CDMS.WebUi.Controllers
{
    public class SupervisorEngineerController : BaseController
    {
        SupervisorEngineerBll SuperEngBll = new SupervisorEngineerBll();
        // GET: SupervisorEngineer
        public JsonResult Edit(SupervisorEngineerUiModel supervisorEngineerUiModel)
        {
            var result = new JsonResult();
            try
            {
                var sup = SuperEngBll.GetSupervisorEngineerInfoByName(supervisorEngineerUiModel.Name);
                if (sup != null)
                {
                    var isCompelete = !string.IsNullOrEmpty(supervisorEngineerUiModel?.Contact) &&
                                      !string.IsNullOrEmpty(supervisorEngineerUiModel?.Code);
                    supervisorEngineerUiModel.Id = sup?.Id ?? 0;
                    var update = SuperEngBll.UpdateExisting(new SupervisorEngineerInfo()
                    {
                        FullName = supervisorEngineerUiModel.Name,
                        Id = supervisorEngineerUiModel.Id,
                        EngineeringCode = supervisorEngineerUiModel.Code,
                        PhoneNumber = supervisorEngineerUiModel.Contact
                    });
                    if (update > 0)
                    {
                        result.Data = new {status = JsonResultStatus.Ok , isCompelete = isCompelete };
                    }
                }
            }
            catch (Exception e)
            {
                result.Data = new { status = JsonResultStatus.Exception, description = "ویرایش با شکست روبرو شد"+Environment.NewLine+ e.Message };
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