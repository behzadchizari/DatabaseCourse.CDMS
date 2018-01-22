using DatabaseCourse.CDMS.Business.BusinessLogic;
using DatabaseCourse.CDMS.WebUi.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseCourse.CDMS.Business.BusinessModel;
using DatabaseCourse.CDMS.WebUi.Classes.UiModel;
using DatabaseCourse.Common.Enums;

namespace DatabaseCourse.CDMS.WebUi.Controllers
{
    public class ProjectController : BaseController
    {
        #region Variables

        ProjectBll projectBll = new ProjectBll();
        SupervisorEngineerBll supervisorEngineerBll = new SupervisorEngineerBll(ThisApp.CurrentUser);

        public enum EditProjectFunctionEnum
        {
            Null = 0,
            Add = 10,
            Delete = 20,
            Edit = 30
        }

        #endregion

        #region Action Methds
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            ThisApp.Session["ProjectId"] = id;
            if (id != 0)
            {
                var projectInfo = projectBll.GetByProjectId(id);
                if (ThisApp.CurrentUser.UserRoles.Any(x => x != UserRoleEnum.SuperAdmin) && (projectInfo == null || projectInfo.UserId != ThisApp.CurrentUser?.Id))
                {
                    Session["ProjectEditResultMessage"] = "پروژه یافت نشد.";
                    return View("Index");
                }

            }
            return View();
        }

        [HttpPost]
        public JsonResult ProjectEdit(EditProjectFunctionEnum fn, ProjectUiModel projectUiModel)
        {
            Session["ProjectEditResultMessage"] = null;
            var projectId = 0;
            var result = new JsonResult();
            try
            {
                if (ThisApp.AccessDeniedType == AccessDeniedType.NoAccessToPage)
                { result.Data = ThisApp.AccessDenied.Message ?? ThisApp.InnerAccessDenied.Message ?? ""; return result; }
                if (fn != EditProjectFunctionEnum.Delete)
                {
                    int.TryParse(ThisApp.Session["ProjectId"]?.ToString(), out projectId);
                    //projectId = (!= null) ? (int)ThisApp.Session["ProjectId "] : 0;
                    projectUiModel.Id = projectId;

                    var checkData = projectUiModel.ChackModel(fn);
                    if (checkData?.Count > 0)
                    {
                        result.Data = new
                        {
                            Status = JsonResultStatus.Exception,
                            Description = checkData
                        };
                        return result;
                    }
                }
                switch (fn)
                {
                    case EditProjectFunctionEnum.Null:
                        break;
                    case EditProjectFunctionEnum.Add:
                        {
                            var supervisor = supervisorEngineerBll.FindSupervisorEngineerInfoByName(projectUiModel.SupervisorEngineerFullName);

                            var projAdded = projectBll.AddNewProject(new ProjectInfo()
                            {
                                Address = projectUiModel.Address,
                                Client = projectUiModel.Client,
                                Id = projectUiModel.Id,
                                SupervisorEngineerId = supervisor,
                                CreationDate = DateTime.Now,
                                GroundOwner = projectUiModel.GroundOwner,
                                GroundType = projectUiModel.GroundType,
                                LastModifiedDate = DateTime.Today,
                                Name = projectUiModel.Name,
                                ProductionLicense = projectUiModel.ProductionLicense,
                                Title = projectUiModel.Title.Replace(" ", "_"),
                                UserId = ThisApp.CurrentUser.Id
                            });

                            if (projAdded != 0)
                            {
                                try
                                {
                                    var path = ThisApp.BaseDirectory + "Attachments//" + projectUiModel.Title;
                                    if (!Directory.Exists(path))
                                    {
                                        Directory.CreateDirectory(path);
                                    }
                                }
                                catch (Exception)
                                {
                                }
                                Session["ProjectEditResultMessage"] = $"پروژه { projectUiModel.Name} با موفقیت <span style=\"color: green; \" > درج </span> شد";
                                ThisApp.AddLogData($"درج پروژه {projectUiModel.Name} با شناسه {projAdded} توسط {ThisApp.CurrentUser.Username}");
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
                    case EditProjectFunctionEnum.Delete:
                        break;
                    case EditProjectFunctionEnum.Edit:
                        {
                            if (projectId != 0)
                            {
                                var supervisor = supervisorEngineerBll.FindSupervisorEngineerInfoByName(projectUiModel.SupervisorEngineerFullName);
                                var projectUpadate = projectBll.UpdateExistingProject(new ProjectInfo()
                                {
                                    Address = projectUiModel.Address,
                                    Client = projectUiModel.Client,
                                    Id = projectUiModel.Id,
                                    SupervisorEngineerId = supervisor,
                                    GroundOwner = projectUiModel.GroundOwner,
                                    GroundType = projectUiModel.GroundType,
                                    LastModifiedDate = DateTime.Now,
                                    Name = projectUiModel.Name,
                                    ProductionLicense = projectUiModel.ProductionLicense,
                                    UserId = ThisApp.CurrentUser.Id
                                });

                                if (projectUpadate != 0)
                                {
                                    Session["ProjectEditResultMessage"] = $"پروژه { projectUiModel.Name} با موفقیت <span style=\"color: blue; \" > تغییر </span> یافت";
                                    ThisApp.AddLogData($"به روز رسانی پروژه {projectUiModel.Name} توسط {ThisApp.CurrentUser.Username}");
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


        [HttpGet]
        public ActionResult ProjectDetails(int id = 0)
        {
            ThisApp.Session["ProjectId"] = id;

            var projectInfo = new ProjectInfo();
            if (id != 0)
            {
                projectInfo = projectBll.GetByProjectId(id);
                if (ThisApp.CurrentUser != null && (ThisApp.CurrentUser.UserRoles.Any(x => x != UserRoleEnum.SuperAdmin) && (projectInfo == null || projectInfo.UserId != ThisApp.CurrentUser?.Id)))
                {
                    Session["ProjectEditResultMessage"] = "پروژه یافت نشد.";
                    return View("Index");
                }

            }
            ViewBag.ProjectInfo = projectInfo;
            return View();
        }
        #endregion

        #region Abstract Methods
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
        #endregion

        #region Helper Methods

        #endregion

    }
}