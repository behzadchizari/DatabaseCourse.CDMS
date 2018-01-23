using DatabaseCourse.CDMS.Business.BusinessLogic;
using DatabaseCourse.CDMS.Business.BusinessModel;
using DatabaseCourse.CDMS.WebUi.Classes;
using DatabaseCourse.Common.Enums;
using DatabaseCourse.Common.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DatabaseCourse.CDMS.WebUi.Controllers.Test
{
    public class BehzadTestController : BaseController
    {
        // GET: BehzadTest
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            var userBll = new UserBll(ThisApp.CurrentUser);
            var e = userBll.AddNewUserInfo(new UserInfo()
            {
                Username = "Admin5",
                Password = "1234",
                UserRoles = new List<Common.Enums.UserRoleEnum> { UserRoleEnum.Admin, UserRoleEnum.CEO },

            });
            if (e != null)
                ViewBag.IsOk = ExceptionUtility.GetAllInnerException(e);
            else
                ViewBag.IsOk = "Ok";
            return View("Index");
        }
        // GET: BehzadTest
        public ActionResult Update()
        {
            var userBll = new UserBll(ThisApp.CurrentUser);
            var us = userBll.GetUserInfoById(1);
            us.Username = "Admin2";
            var e = userBll.UpdateExistingUserInfor(us);
            if (e != null)
                ViewBag.IsOk = ExceptionUtility.GetAllInnerException(e);
            else
            { ViewBag.IsOk = "Ok"; }
            return View("Index");
        }
        // GET: BehzadTest
        public ActionResult Login(string p, string u)
        {
            var userBll = new UserBll(ThisApp.CurrentUser);
            var e = userBll.GetUserInfoByUserNameAndPassword(u, p);
            if (e != null)
            {
                ViewBag.IsOk = "";
                foreach (var item in e.UserRoles)
                {
                    ViewBag.IsOk += item + " ";
                }
                ViewBag.IsOk += e.Username;
                var er = e.UserRoles;

            }
            else
                ViewBag.IsOk = "NOk";
            return View("Index");
        }


        [HttpPost]
        public JsonResult UploadHomeReport(string id)
        {
            try
            {
                foreach (string file in Request.Files)
                {
                    var fileContent = Request.Files[file];
                    if (fileContent != null && fileContent.ContentLength > 0)
                    {
                        //    var inputPath = Server.MapPath(ThisApp.BaseDirectory + "\\Attachments\\Twin_Tower");
                        //    var rootPath = Server.MapPath("~/");
                        //    //you could use this outputPath in hyperlink
                        //    var outputPath = inputPath.Replace(rootPath, "/").Replace(@"\", @" / ");
                        // get a stream
                        var stream = fileContent.InputStream;
                        // and optionally write the file to disk
                        var fileName = Path.GetFileName(file);
                        var path = Path.Combine(ThisApp.BaseDirectory + "\\Attachments\\Twin_Tower", fileContent.FileName);
                        using (var fileStream = System.IO.File.Create(path))
                        {
                            stream.CopyTo(fileStream);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Upload failed");
            }

            return Json("File uploaded successfully");
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