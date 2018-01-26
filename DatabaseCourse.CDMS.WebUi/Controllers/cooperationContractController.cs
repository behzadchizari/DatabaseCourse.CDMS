using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseCourse.CDMS.Business.BusinessLogic;
using DatabaseCourse.CDMS.Business.BusinessModel;
using DatabaseCourse.CDMS.WebUi.Classes;
using DatabaseCourse.Common.Enums;

namespace DatabaseCourse.CDMS.WebUi.Controllers
{
    public class CooperationContractController : BaseController
    {
        private CooperationContractBll coBll = new CooperationContractBll();


        [HttpPost]
        public JsonResult EndOfWork(int? id)
        {
            var result = new JsonResult();
            var coopBll = new CooperationContractBll();
            try
            {
                    var ended = coopBll.UpdateExsisting(new CooperationContractInfo()
                    {
                        Id = id??0,
                        EndDate = DateTime.Now
                    });
            }
            catch (Exception)
            {
            }
            return null;
        }

        public JsonResult AddCooperation(List<CooperationUiModel> cooperationUiModelList)
        {
            var result = new JsonResult();
            try
            {
                foreach (var item in cooperationUiModelList)
                {
                    var cond = coBll.GetCooperationContractInfosByProjectId(item.ProjectId)
                        .FirstOrDefault(x => x.ContractorId == item.Id && x.EndDate == null);
                    if (cond == null)
                    {
                        coBll.AddNewCooperationContract(new CooperationContractInfo()
                        {
                            ContractorId = item.Id,
                            ProjectId = item.ProjectId,
                            StartDate = DateTime.Now,
                            WageType = item.Wage
                        });
                    }
                }
                result.Data = new { status = JsonResultStatus.Ok };
            }
            catch (Exception )
            {
                result.Data = new { status = JsonResultStatus.Exception };
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