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
    public class ContractorController : BaseController
    {
        private ContractorBll ContractorBll = new ContractorBll();

        public enum EditContractorFunctionEnum
        {
            Add = 10,
            Update = 20,
            Delete = 30
        }

        // GET: Contractor
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            ThisApp.Session["ContractorId"] = id;
            if (id != 0)
            {
                var Contractor = ContractorBll.GetContractorById(id);
                if (Contractor == null)
                {
                    Session["ContractorEditResultMessage"] = "پروژه یافت نشد.";
                    return View("Index");
                }
                else
                {
                    ViewBag.ContractorData = Contractor;
                }

            }
            return View();
        }


        [HttpPost]
        public ActionResult ContractorEdit(EditContractorFunctionEnum fn, ContractorUiModel contractorUiModel)
        {

            Session["ContractorEditResultMessage"] = null;
            var contractId = 0;
            var result = new JsonResult();
            try
            {
                if (ThisApp.AccessDeniedType == AccessDeniedType.NoAccessToPage)
                { result.Data = ThisApp.AccessDenied.Message ?? ThisApp.InnerAccessDenied.Message ?? ""; return result; }
                if (fn != EditContractorFunctionEnum.Delete)
                {
                    int.TryParse(ThisApp.Session["ContractorId"]?.ToString(), out contractId);
                    //projectId = (!= null) ? (int)ThisApp.Session["ProjectId "] : 0;
                    contractorUiModel.Id = contractId;

                    //var checkData = contractorUiModel.ChackModel(fn);
                    //if (checkData?.Count > 0)
                    //{
                    //    result.Data = new
                    //    {
                    //        Status = JsonResultStatus.Exception,
                    //        Description = checkData
                    //    };
                    //    return result;
                    //}
                }
                switch (fn)
                {
                    case EditContractorFunctionEnum.Add:
                        {

                            var contractorAdded = ContractorBll.AddNewContractorInfo(new ContractorInfo()
                            {
                                NationalId = contractorUiModel.NationalId,
                                Contact = contractorUiModel.Contact,
                                FirstName = contractorUiModel.FirstName,
                                LastName = contractorUiModel.LastName,
                                InsuranceNo = contractorUiModel.InsuranceNo,
                                FirstCooperationDate = DateTime.Now
                            });

                            if (contractorAdded != 0)
                            {
                                Session["ContractorId"] = $"پیمانکار { contractorUiModel.FirstName} {contractorUiModel.LastName} با موفقیت <span style=\"color: green; \" > درج </span> شد";
                                ThisApp.AddLogData($"درج پیمانکار{ contractorUiModel.FirstName} {contractorUiModel.LastName}با شناسه {contractorAdded} توسط {ThisApp.CurrentUser.Username}");
                                result.Data = new
                                {
                                    Status = JsonResultStatus.Ok,
                                };
                            }
                            else
                            {
                                result.Data = new
                                {
                                    Status = JsonResultStatus.Exception,
                                    Description = new List<Exception>() { new Exception("پروژه درج نشد") }
                                };
                            }
                            break;
                        }
                    case EditContractorFunctionEnum.Delete:
                        break;
                    case EditContractorFunctionEnum.Update:
                        {
                            if (contractId != 0)
                            {
                                var projectUpadate = ContractorBll.UpdateContractorInfo(new ContractorInfo()
                                {
                                    NationalId = contractorUiModel.NationalId,
                                    Id = contractorUiModel.Id,
                                    Contact = contractorUiModel.Contact,
                                    FirstName = contractorUiModel.FirstName,
                                    LastName = contractorUiModel.LastName,
                                    InsuranceNo = contractorUiModel.InsuranceNo
                                });

                                if (projectUpadate != 0)
                                {
                                    Session["ContractorId"] = $"پیمانکار  {contractorUiModel.FirstName} {contractorUiModel.LastName} با موفقیت <span style=\"color: blue; \" > تغییر </span> یافت";
                                    ThisApp.AddLogData($"به روز رسانی پیمانکار {contractorUiModel.FirstName} {contractorUiModel.LastName} توسط {ThisApp.CurrentUser.Username}");
                                    result.Data = new
                                    {
                                        Status = JsonResultStatus.Ok,
                                    };
                                }
                            }
                            else
                            {
                                result.Data = new
                                {
                                    Status = JsonResultStatus.Exception,
                                    Description = new List<Exception>() { new Exception("به روز رسانی با شکست روبرو شد") }
                                };
                            }
                            break;
                        }
                }
            }
            catch (Exception e)
            {
                result.Data = new
                {
                    Status = JsonResultStatus.Exception,
                    Description = new List<Exception>() { e }
                };
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